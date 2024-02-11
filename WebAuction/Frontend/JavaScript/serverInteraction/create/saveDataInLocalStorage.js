import { main } from '../../photoEditor/main.js'

let dataSaveInLocalStorage = {};

dataSaveInLocalStorage.main = function () {
    let nameForm = document.forms['editName'];
    nameForm.addEventListener('submit', (event) => {
        event.preventDefault();
        let newName = nameForm['newName'].value;
        localStorage.setItem('name', newName);
    })

    let descriptionForm = document.forms['editDescription'];
    descriptionForm.addEventListener('submit', (event) => {
        event.preventDefault();
        let descriptionNew = descriptionForm.firstElementChild.value;
        localStorage.setItem('description', descriptionNew);
    })

    let startingBidForm = document.forms['editStartingBid'];
    startingBidForm.addEventListener('submit', (event) => {
        event.preventDefault();
        let newBid = startingBidForm['newBid'].value;
        localStorage.setItem('startingBid', newBid);
    })

    let deadlineInput = document.forms['editDeadline']['newDeadline'];
    deadlineInput.addEventListener('change', () => {
        let newDeadline = deadlineInput.value;
        localStorage.setItem('startingBid', newDeadline);
    })


    let photoInput = document.querySelector('form[name="addPhoto"]>input');
    photoInput.addEventListener('change', async (event) => {
        let selectedPhoto = event.target.files[0];
        await pushPhotoToLocalStorage(selectedPhoto);
        refactorHtmlToEditPhoto();
    })

    async function pushPhotoToLocalStorage(photoFile) {
        return new Promise((resolve) => {
            const reader = new FileReader();
            reader.onload = function () {
                const base64String = reader.result;
                let photos = JSON.parse(localStorage.getItem('photos'));
                photos.push(base64String);
                localStorage.setItem('photos', JSON.stringify(photos));
                console.log(JSON.parse(localStorage.getItem('photos')));
                resolve();
            };
            reader.readAsDataURL(photoFile);
        });
    }

    function refactorHtmlToEditPhoto() {
        let photosBlock = document.querySelector('.auctionPhotos');
        let currentPhotoBlock = photosBlock.firstElementChild;

        let currentPhotoImage = createNode(
            '<img class="currentPhoto">');
        let thumbnailsBlock = createNode(
            '<div class="thumbnails thin-scrollbar"></div>');

        currentPhotoImage.setAttribute('src',
            JSON.parse(localStorage.getItem('photos'))[0]
        )
        thumbnailsBlock.appendChild(currentPhotoImage.cloneNode(false));

        currentPhotoBlock.querySelector('form').remove();
        currentPhotoBlock.setAttribute('class', 'edit-photo');
        photosBlock.insertBefore(thumbnailsBlock, currentPhotoBlock);
        currentPhotoBlock.appendChild(currentPhotoImage);
        main();
    }

    function createNode(html) {
        let surrogate = document.createElement('div');
        surrogate.innerHTML = html;
        return surrogate.firstElementChild;
    }
}

dataSaveInLocalStorage.main();
