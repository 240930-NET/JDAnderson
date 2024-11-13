let generalJump = (id, wordOrChar) => {
    let header = document.querySelector(`.hero-content #${id}`);
    
    // Ensure header exists
    if (!header) {
        console.error(`Element with ID "${id}" not found.`);
        return;
    }

    document.addEventListener("DOMContentLoaded", () => {
        // Split text based on word or char 
        const textContainer = wordOrChar === 'word'
            ? header.textContent.split(' ') // Split by spaces for words
            : header.textContent.split(''); // Split into characters

        // Map over the array and wrap each item in a span
        header.innerHTML = textContainer.map((item, index) => {
            if (item === "passion") {
                return `<span style="--${wordOrChar}-index: ${index}">${item}</span><br>`;
            } else {
                return `<span style="--${wordOrChar}-index: ${index}">${item === '' ? '&nbsp;' : item}</span>`;
            }
        }).join(' '); // Join with space for words

        // Wait for the appear animation to finish before starting the jump animation
        header.addEventListener('animationend', () => {
            const spans = header.querySelectorAll('span');
            spans.forEach((span, index) => {
                span.style.animation = `jumpLetter 0.6s ease-in-out 2 calc(var(--${wordOrChar}-index) * 0.1s + 2s) forwards`;
                span.style.animationDelay = `${index * 0.1}s`; // Delay based on index
            });
        }, { once: true }); // Remove listener after it runs
    });
}

let hoverEffect = (ids) => {
    ids.forEach((id) => {
        let text = document.getElementById(id);
        
        // Ensure text exists
        if (!text) {
            console.error(`Element with ID "${id}" not found.`);
            return;
        }

        text.addEventListener("mouseover", () => {
            // Remove any existing animation class to reset it
            text.style.animation = "none"; 
            // Trigger reflow to restart animation
            void text.offsetWidth; 
            text.style.animation = "hoverHeader 0.5s ease-in 0.2s 3 alternate";
            text.style.color = "blue"; // Change color on hover
        });

        text.addEventListener("animationend", () => {
            // Reset color after animation ends to ensure it can be triggered again
            text.style.color = "white"; 
        });

        text.addEventListener("mouseleave", () => {
            // Optionally reset styles or perform other actions on mouse leave
            text.style.color = "white"; // Reset color on mouse leave
        });
    });
}

const init = () => {
    hoverEffect(["passion", "photo"]);
    generalJump('passion', 'char');
    generalJump('photo', 'char');

    // Uncomment the line below to animate words instead:
    // generalJump('word');
}

init();