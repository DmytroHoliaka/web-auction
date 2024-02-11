let homeLink = document.querySelector('.header li');

homeLink.addEventListener('click', (event) => {
    if (!isDataEntered()) {
        alert('Please, enter all necessary data!');
        event.preventDefault();
        return;
    }

    event.preventDefault();

    const dataToSend = {
        Name: localStorage.getItem('name'),
        Description: localStorage.getItem('description'),
        StartPrice: localStorage.getItem('startingBid'),
        StartDate: getCurrentDate(),
        EndDate: localStorage.getItem('deadline'),
        CreatorId: getUserIdFromCookies(),
        Images: localStorage.getItem('photos'),
    };

    fetch("Auction/Create", {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(dataToSend)
    })
        .then(response => {
            window.location.href = '/index.html';
            alert("Your lot was successfully added");
        })
        .catch(error => {
            window.location.href = '/index.html';
            console.error('There was a problem with your fetch operation:', error.message || 'Unknown error');
            alert('An error occurred while processing your request.');
        });
});


function isDataEntered() {
    if (localStorage.getItem('name') === null) {
        return false;
    } if (localStorage.getItem('photos') === JSON.stringify([])) {
        return false;
    } if (localStorage.getItem('description') === null) {
        return false;
    } if (localStorage.getItem('startingBid') === null) {
        return false;
    } if (localStorage.getItem('deadline') === null) {
        return false;
    }
    return true;
}

function getUserIdFromCookies() {
    const cookies = document.cookie.split('; ');
    const userIdCookie = cookies.find(row => row.startsWith('userId='));
    return userIdCookie ? userIdCookie.split('=')[1] : null;
}

function getCurrentDate() {
    let d = new Date().toISOString();
    return d;
}