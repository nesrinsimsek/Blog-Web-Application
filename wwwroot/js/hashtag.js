let input, hashtagArray, container, t;

input = document.querySelector('#hashtags');
container = document.querySelector('.tag-container');
hashtagArray = [];

input.addEventListener('keypress', function (e) {
    
        alert("hi");
      var text = document.createTextNode(input.value);
      var p = document.createElement('p');
      container.appendChild(p);
      p.appendChild(text);
      p.classList.add('tag');
      input.value = '';
      
      let deleteTags = document.querySelectorAll('.tag');
      
      for(let i = 0; i < deleteTags.length; i++) {
        deleteTags[i].addEventListener('click', () => {
          container.removeChild(deleteTags[i]);
        });
      }
    
});