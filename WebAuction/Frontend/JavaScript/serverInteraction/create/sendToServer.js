let homeLink = document.querySelector('.header li');

homeLink.addEventListener('click', (event) => {
    if (!isDataEntered()) {
        alert('Please, enter all necessary data!');
        event.preventDefault();
        return;
    }
    fetch('/Auction/Create?' +
        `name=${localStorage.getItem('name')}&` +
        `photos=${localStorage.getItem('photos')}&` +
        `description=${localStorage.getItem('description')}&` +
        `startingBid=${localStorage.getItem('startingBid')}&` +
        `deadline=${localStorage.getItem('deadline')}&` +
        `StartDate=${getCurrentDate()}&` +
        `CreatorId=${getUserIdFromCookies()}`
    ).then(response => response.json())
        .then(data => console.log('Server: ', data))
        .catch(error => {
            alert(error);
            event.preventDefault();
        })
})

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