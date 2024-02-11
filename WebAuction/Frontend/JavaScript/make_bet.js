document.addEventListener('DOMContentLoaded', function () {
    const form = document.forms['bidForm'];

    form.addEventListener('submit', function (event) {
        event.preventDefault();

        const params = new URLSearchParams(window.location.search);
        const auctionId = params.get('auctionId');

        const currentDate = new Date().toISOString();

        function getUserIdFromCookies() {
            const cookies = document.cookie.split('; ');
            const userIdCookie = cookies.find(row => row.startsWith('userId='));
            return userIdCookie ? userIdCookie.split('=')[1] : null;
        }

        const userId = getUserIdFromCookies();

        if (!userId) {
            console.error('UserId not found in cookies.');
            return;
        }

        const dataToSend = {
            bid: form.elements['bid'].value,
            date: currentDate,
            userId: userId,
            auctionId: auctionId,
        };

        fetch(form.action, {
            method: form.method,
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(dataToSend)
        })
            .then(response => response.text())
            .then(text => {
                form.reset();
                alert(text);
            })
            .catch(error => {
                console.error('There was a problem with your fetch operation:', error);
                alert('An error occurred while submitting your bid. Please try again.');
            });
    });
});
