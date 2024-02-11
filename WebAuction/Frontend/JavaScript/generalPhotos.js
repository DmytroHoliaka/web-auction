let photoPicker = {};

photoPicker.main = function(){
    console.log(1);
    let thumbnails = document.getElementsByClassName('thumbnails')[0];
    let currentPhoto = document.getElementsByClassName('currentPhoto')[0];
    
    function thumbnailClick(event){
        console.log(2);
        for(let child of thumbnails.children){
            child.removeAttribute('class');
        };
        let img = event.target;
        img.setAttribute('class', 'currentPhotoThumbnail');
        currentPhoto.setAttribute('src', img.src);
    }
    
    for(let child of thumbnails.children){
        console.log(child);
        child.onclick = thumbnailClick;
    }
}

photoPicker.main();