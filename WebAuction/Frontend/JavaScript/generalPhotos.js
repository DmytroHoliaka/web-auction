let photoPicker = {};

photoPicker.main = function(){
    let thumbnails = document.getElementsByClassName('thumbnails')[0];
    let currentPhoto = document.getElementsByClassName('currentPhoto')[0];
    
    function thumbnailClick(event){
        for(let child of thumbnails.children){
            child.removeAttribute('class');
        };
        let img = event.target;
        img.setAttribute('class', 'currentPhotoThumbnail');
        currentPhoto.setAttribute('src', img.src);
    }
    
    for(let child of thumbnails.children){
        if (child.tagName === 'IMG') {
            child.onclick = thumbnailClick;
        }
    }
}

//photoPicker.main();

export { photoPicker };