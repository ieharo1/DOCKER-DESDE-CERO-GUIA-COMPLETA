// Main JavaScript para Docker Desde Cero

document.addEventListener('DOMContentLoaded', function() {
    console.log('🐳 Docker Desde Cero - Sitio cargado correctamente');

    // Smooth scroll para enlaces internos
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function(e) {
            e.preventDefault();
            const targetId = this.getAttribute('href');
            
            // Si es un enlace a un tema, mostrar el contenido
            if (targetId.startsWith('#tema')) {
                showTopicContent(targetId);
                return;
            }
            
            const target = document.querySelector(targetId);
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });

    // Función para mostrar contenido de tema
    function showTopicContent(topicId) {
        const content = document.getElementById(topicId);
        if (content) {
            // Ocultar todos los contenidos
            document.querySelectorAll('.content-detail').forEach(el => {
                el.style.display = 'none';
            });
            
            // Mostrar el contenido seleccionado
            content.style.display = 'block';
            
            // Scroll suave al contenido
            setTimeout(() => {
                content.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }, 100);
        }
    }

    // Mostrar todos los contenidos al cargar
    document.querySelectorAll('.content-detail').forEach(el => {
        el.style.display = 'none';
    });

    // Animación al hacer scroll
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver(function(entries) {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }
        });
    }, observerOptions);

    // Observar elementos para animación
    document.querySelectorAll('.module, .resource-card, .code-block, .topic-card').forEach(el => {
        el.style.opacity = '0';
        el.style.transform = 'translateY(20px)';
        el.style.transition = 'opacity 0.5s ease, transform 0.5s ease';
        observer.observe(el);
    });

    // Header scroll effect
    let lastScroll = 0;
    const header = document.querySelector('.header');

    window.addEventListener('scroll', () => {
        const currentScroll = window.pageYOffset;

        if (currentScroll > 100) {
            header.style.background = 'rgba(56, 77, 84, 0.98)';
            header.style.boxShadow = '0 2px 10px rgba(0,0,0,0.1)';
        } else {
            header.style.background = 'var(--secondary-color)';
            header.style.boxShadow = 'none';
        }

        lastScroll = currentScroll;
    });

    // Copy to clipboard functionality for code blocks
    document.querySelectorAll('.code-block, .content-body pre').forEach(block => {
        const copyButton = document.createElement('button');
        copyButton.className = 'copy-btn';
        copyButton.textContent = '📋 Copiar';
        copyButton.style.cssText = `
            position: absolute;
            top: 10px;
            right: 10px;
            background: var(--accent-color);
            border: none;
            padding: 5px 10px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 0.8rem;
            z-index: 10;
        `;

        if (getComputedStyle(block).position === 'static') {
            block.style.position = 'relative';
        }
        block.appendChild(copyButton);

        copyButton.addEventListener('click', () => {
            const code = block.querySelector('code') || block;
            const text = code.textContent;
            navigator.clipboard.writeText(text).then(() => {
                copyButton.textContent = '✅ Copiado!';
                setTimeout(() => {
                    copyButton.textContent = '📋 Copiar';
                }, 2000);
            });
        });
    });

    // Active navigation highlighting
    const sections = document.querySelectorAll('section[id]');

    window.addEventListener('scroll', () => {
        let current = '';
        sections.forEach(section => {
            const sectionTop = section.offsetTop;
            const sectionHeight = section.clientHeight;
            if (window.pageYOffset >= sectionTop - 100) {
                current = section.getAttribute('id');
            }
        });

        document.querySelectorAll('.nav-menu a').forEach(link => {
            link.classList.remove('active');
            if (link.getAttribute('href') === `#${current}`) {
                link.classList.add('active');
            }
        });
    });

    // Mobile menu toggle
    const createMobileMenu = () => {
        if (window.innerWidth <= 768) {
            const navMenu = document.querySelector('.nav-menu');
            if (!navMenu.classList.contains('mobile-ready')) {
                navMenu.classList.add('mobile-ready');
            }
        }
    };

    window.addEventListener('resize', createMobileMenu);
    createMobileMenu();

    // Contador de visitas
    let visitCount = localStorage.getItem('dockerVisitCount') || 0;
    visitCount++;
    localStorage.setItem('dockerVisitCount', visitCount);
    console.log(`Visitas: ${visitCount}`);

    // Mensaje de bienvenida en consola
    console.log('%c🐳 ¡Bienvenido a Docker Desde Cero!', 'font-size: 20px; color: #0db7ed; font-weight: bold;');
    console.log('%cAprende Docker de manera fácil y práctica', 'font-size: 14px; color: #f5c542;');
});

// Syntax highlighting simple
function highlightSyntax() {
    const codeBlocks = document.querySelectorAll('code');
    
    codeBlocks.forEach(block => {
        const code = block.innerHTML;
        
        // Resaltar palabras clave de bash
        const bashKeywords = ['docker', 'run', 'stop', 'start', 'rm', 'ps', 'images', 'pull', 'push', 'build'];
        bashKeywords.forEach(keyword => {
            const regex = new RegExp(`\\b${keyword}\\b`, 'g');
            block.innerHTML = block.innerHTML.replace(regex, `<span class="keyword" style="color: #ff79c6;">${keyword}</span>`);
        });
    });
}

// Ejecutar después de cargar
setTimeout(highlightSyntax, 100);
