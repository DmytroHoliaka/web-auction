document.addEventListener('DOMContentLoaded', function () {
    fetchAuctionData();
});

function fetchAuctionData() {
    fetch('/Data/AuctionSummaries')
        .then(response => response.json())
        .then(data => {
            const container = document.getElementById('auctionsContainer');
            container.innerHTML = ''; 

            data.forEach(auction => {
                const auctionDiv = document.createElement('div');
                auctionDiv.className = 'image';

                const img = document.createElement('img');

                if (auction.base64Image) {
                    img.src = `data:image/jpg;base64,${auction.base64Image}`;
                }
                else {
                    img.src = 'images/img_placeholder.jpeg';
                }
                auctionDiv.appendChild(img);

                const titleDiv = document.createElement('div');
                titleDiv.className = 'description first';
                const titleLink = document.createElement('a');
                titleLink.href = `bet_placeholder.html?auctionId=${auction.auctionId}`; 
                titleLink.textContent = auction.listingTitle;
                titleDiv.appendChild(titleLink);
                auctionDiv.appendChild(titleDiv);

                auctionDiv.appendChild(createDescriptionElement(`Starting bid: ${auction.startingBid}`));
                auctionDiv.appendChild(createDescriptionElement(`Current bid: ${auction.currentBid}`));
                auctionDiv.appendChild(createDescriptionElement(`${formatDateTime(auction.auctionEnds)}`));

                container.appendChild(auctionDiv);
            });
        })
        .catch(error => console.error('Error fetching auction data:', error));
}

function createDescriptionElement(text, additionalClass = '') {
    const p = document.createElement('p');
    p.className = `description ${additionalClass}`;
    p.textContent = text;
    return p;
}

function formatDateTime(auctionEnds) {
    const auctionEndDate = new Date(auctionEnds);
    return auctionEndDate.toLocaleDateString('en-US', {
        year: 'numeric', month: 'numeric', day: 'numeric',
        hour: '2-digit', minute: '2-digit', hour12: true
    });
}
