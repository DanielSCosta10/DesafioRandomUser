const apiBaseUrl = 'http://localhost:5073/api';

let allUsers = [];
let currentPage = 1;
const usersPerPage = 10;

async function getUserCount() {
    try {
        const response = await fetch(`${apiBaseUrl}/User/GetUserCount`);
        if (!response.ok) {
            throw new Error('Erro ao buscar total de usuários');
        }
        const count = await response.json();
        updateUserCount(count);
        return count;
    } catch (error) {
        console.error('Erro ao obter total de usuários:', error);
        return 0;
    }
}

async function getAllUsers() {
    try {
        const totalCount = await getUserCount();

        const response = await fetch(`${apiBaseUrl}/User/GetAllUsers`);
        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(`Erro ao conectar na api: ${errorData.message}`);
        }
        const users = await response.json();
        
        allUsers = users.reverse();
        
        updateUserCount(allUsers.length);
        
        renderUserTable(currentPage);
        
        setupPagination();
    } catch (error) {
        console.error('Erro ao obter usuários:', error.message);
    }
}

function updateUserCount(count) {
    const totalUsersElement = document.getElementById('totalUsers');
    totalUsersElement.textContent = `Total de Usuários: ${count}`;
}

function renderUserTable(page) {
    const userTableBody = document.querySelector('#userTable tbody');
    userTableBody.innerHTML = '';

    const startIndex = (page - 1) * usersPerPage;
    const endIndex = startIndex + usersPerPage;
    const paginatedUsers = allUsers.slice(startIndex, endIndex);

    paginatedUsers.forEach(user => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${user.firstName}</td>
            <td>${user.lastName}</td>
            <td>${user.state}</td>
            <td>
                <button class="editButton" data-user-id="${user.id}">Editar</button>
            </td>
        `;
        userTableBody.appendChild(row);
    });

    addEditButtonListeners();
}

function setupPagination() {
    const totalPages = Math.ceil(allUsers.length / usersPerPage);
    
    const existingPagination = document.getElementById('pagination');
    if (existingPagination) {
        existingPagination.remove();
    }

    const paginationContainer = document.createElement('div');
    paginationContainer.id = 'pagination';
    paginationContainer.classList.add('pagination');

    const prevButton = document.createElement('button');
    prevButton.textContent = 'Anterior';
    prevButton.disabled = currentPage === 1;
    prevButton.addEventListener('click', () => {
        if (currentPage > 1) {
            currentPage--;
            renderUserTable(currentPage);
            updatePaginationControls();
        }
    });

    const nextButton = document.createElement('button');
    nextButton.textContent = 'Próxima';
    nextButton.disabled = currentPage === totalPages;
    nextButton.addEventListener('click', () => {
        if (currentPage < totalPages) {
            currentPage++;
            renderUserTable(currentPage);
            updatePaginationControls();
        }
    });

    const pageInfo = document.createElement('span');
    pageInfo.textContent = `Página ${currentPage} de ${totalPages}`;

    paginationContainer.appendChild(prevButton);
    paginationContainer.appendChild(pageInfo);
    paginationContainer.appendChild(nextButton);

    document.querySelector('#userTable').after(paginationContainer);
}

function updatePaginationControls() {
    const totalPages = Math.ceil(allUsers.length / usersPerPage);
    const prevButton = document.querySelector('#pagination button:first-child');
    const nextButton = document.querySelector('#pagination button:last-child');
    const pageInfo = document.querySelector('#pagination span');

    prevButton.disabled = currentPage === 1;
    nextButton.disabled = currentPage === totalPages;
    pageInfo.textContent = `Página ${currentPage} de ${totalPages}`;
}

function displayUsers(newUsers) {
    allUsers.unshift(...newUsers);
    
    updateUserCount(allUsers.length);
    
    currentPage = 1;
    
    renderUserTable(currentPage);
    setupPagination();
}

async function addRandomUser() {
    try {
        const response = await fetch(`${apiBaseUrl}/user/AddRandomUser`);

        // Verificar o tipo de conteúdo da resposta
        const contentType = response.headers.get('Content-Type');
        if (contentType && contentType.includes('application/json')) {
            // Tentar fazer o parse para JSON
            const newUser = await response.json();
            displayUsers([newUser]);
        } else {
            // Capturar o corpo da resposta como texto para diagnosticar
            const errorText = await response.text();
            console.error('Resposta não-JSON recebida:', errorText);
            throw new Error('Resposta não está no formato JSON esperado.');
        }
        
    } catch (error) {
        console.error('Erro ao adicionar usuário aleatório:', error);
    }
}
async function addMultipleUsers() {
    const userCountInput = document.getElementById('userCount');
    const userCount = parseInt(userCountInput.value);

    try {
        const response = await fetch(`${apiBaseUrl}/user/AddMulipleRandomUser?number=${userCount}`);

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Erro na requisição: ${response.statusText}`);
        }

        const newUsers = await response.json();
        displayUsers(newUsers);

    } catch (error) {
        console.error('Erro ao adicionar múltiplos usuários aleatórios:', error);
    }
}

async function editUser(userId, firstName, lastName, state) {
    try {
        const response = await fetch(`${apiBaseUrl}/user/UpdateUser/${userId}`, {
            method: 'PATCH',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ firstName, lastName, state })
        });
        const updatedUser = await response.json();
        
        const userIndex = allUsers.findIndex(u => u.id === userId);
        if (userIndex !== -1) {
            allUsers[userIndex] = updatedUser;
        }
        

        renderUserTable(currentPage);

        const updateMessageElement = document.getElementById('updateMessage');
        updateMessageElement.textContent = 'Usuário atualizado com sucesso!';
        updateMessageElement.style.display = 'block';

        setTimeout(() => {
            updateMessageElement.style.display = 'none';
        }, 3000);
    } catch (error) {
        console.error('Erro ao editar usuário:', error);
    }
}

function addEditButtonListeners() {
    const editButtons = document.querySelectorAll('.editButton');
    editButtons.forEach(button => {
        button.addEventListener('click', () => {
            const userId = button.dataset.userId;
            const userRow = button.closest('tr');
            const firstName = userRow.children[0].textContent;
            const lastName = userRow.children[1].textContent;
            const state = userRow.children[2].textContent;

            document.getElementById('userId').value = userId;
            document.getElementById('firstName').value = firstName;
            document.getElementById('lastName').value = lastName;
            document.getElementById('state').value = state;
        });
    });
}

document.getElementById('userForm').addEventListener('submit', (event) => {
    event.preventDefault();
    const userId = document.getElementById('userId').value;
    const firstName = document.getElementById('firstName').value;
    const lastName = document.getElementById('lastName').value;
    const state = document.getElementById('state').value;
    editUser(userId, firstName, lastName, state);
});

document.getElementById('addRandomUser').addEventListener('click', addRandomUser);

document.getElementById('addMultipleUsers').addEventListener('click', addMultipleUsers);

getAllUsers();