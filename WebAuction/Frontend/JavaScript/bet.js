document.addEventListener('DOMContentLoaded', function () {
    const params = new URLSearchParams(window.location.search);
    const auctionId = params.get('auctionId');

    if (auctionId) {
        fetch(`/Bet/Content?auctionId=${auctionId}`)
            .then(response => response.json())
            .then(data => {
                if (data.redirectToSignIn) {
                    window.location.href = "/sign_in.html";
                    return; 
                }

                const table = document.getElementById('history');

                data.history.forEach(historyItem => {
                    const element = document.createElement('tr');

                    element.innerHTML =
                        `
                         <th>${historyItem.username}</th>
                         <th class="ht-money">${historyItem.bid} $</th>
                         <th class="ht-date">${formatDateTime(historyItem.date)}</th>
                        `;

                    table.appendChild(element);
                });

                document.getElementById("title").textContent = data.title;
                document.getElementById("startingBid").textContent = data.startBet + "$";
                document.getElementById("deadline").textContent = formatDateTime(data.deadline);
                document.getElementById("description").textContent = data.description;

                if (data.mainImage) {
                    const imagesContainer = document.getElementById("imagesContainer");
                    const mainImg = document.createElement('img');
                    mainImg.className = "currentPhoto";
                    mainImg.src = `data:image/jpg;base64,${data.mainImage}`;
                    imagesContainer.appendChild(mainImg);

                    const images = document.getElementById("images");
                    const img = document.createElement('img');
                    img.className = "currentPhotoThumbnail";
                    img.src = `data:image/jpg;base64,${data.mainImage}`;
                    images.appendChild(img);

                    data.images = data.images.filter(image => image !== data.mainImage);
                }
                else {
                    const imagesContainer = document.getElementById("imagesContainer");
                    const img = document.createElement('img');
                    img.className = "currentPhoto";
                    img.src = 'https://via.placeholder.com/200x200?text=No+Image';
                    imagesContainer.appendChild(img);
                }

                if (data.images) {
                    data.images.forEach(image => {

                        const imagesContainer = document.getElementById("images");
                        const img = document.createElement('img');
                        img.src = `data:image/jpg;base64,${image}`;
                        imagesContainer.appendChild(img);
                    });
                }
            })
            .catch(error => console.error('Failed to fetch auction content:', error));
    }
});


function formatDateTime(auctionEnds) {
    const auctionEndDate = new Date(auctionEnds);
    return auctionEndDate.toLocaleDateString('en-US', {
        year: 'numeric', month: 'numeric', day: 'numeric',
        hour: '2-digit', minute: '2-digit', hour12: true
    });
}