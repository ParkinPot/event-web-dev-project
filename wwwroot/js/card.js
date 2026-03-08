const eventsData = window.eventData || [];
const container = document.getElementById('event-list-container');

function renderCards(data) {
    container.innerHTML = '';
    if (data.length === 0) {
        container.innerHTML = '<p style="color:#9ca3af; padding:24px;">No events found.</p>';
        return;
    }
    data.forEach((event, index) => {
        const card = document.createElement('div');
        card.classList.add('event-card');
        card.style.animationDelay = `${index * 0.3}s`;

        const cardHeader = document.createElement('div');
        cardHeader.classList.add('card-header');

        const timeBadge = document.createElement('span');
        timeBadge.classList.add('time-badge');
        timeBadge.textContent = event.postedAt;

        const bookmarkBtn = document.createElement('button');
        bookmarkBtn.classList.add('bookmark-btn');

        const bookmarkIcon = document.createElement('i');
        bookmarkIcon.classList.add('fa-regular', 'fa-bookmark');
        bookmarkBtn.appendChild(bookmarkIcon);
        cardHeader.append(timeBadge, bookmarkBtn);

        const cardBody = document.createElement('div');
        cardBody.classList.add('card-body');

        const titleDiv = document.createElement('h2');
        titleDiv.textContent = event.title;

        const authorDiv = document.createElement('p');
        authorDiv.classList.add('author');
        authorDiv.textContent = `By ${event.postedBy}`;
        cardBody.append(titleDiv, authorDiv);

        const cardFooter = document.createElement('div');
        cardFooter.classList.add('card-footer');

        const metaInfo = document.createElement('div');
        metaInfo.classList.add('meta-info');

        function createMetaSpan(iconClass, text) {
            const span = document.createElement('span');
            const icon = document.createElement('i');
            iconClass.split(' ').forEach(cls => icon.classList.add(cls));
            icon.classList.add('icon-primary');
            span.appendChild(icon);
            span.append(` ${text}`);
            return span;
        }

        const categorySpan = createMetaSpan('fa-solid fa-briefcase', event.category);
        const appliedSpan  = createMetaSpan('fa-regular fa-square-check', `${event.currentMembers}/${event.maxMembers} applied`);
        const expiresSpan  = createMetaSpan('fa-regular fa-clock', `expires ${event.expiresAt}`);
        const statusSpan   = document.createElement('span');
        statusSpan.textContent = event.status;
        statusSpan.classList.add(`status-${event.status.toLowerCase()}`);

        metaInfo.append(categorySpan, appliedSpan, expiresSpan, statusSpan);

        const btnPrimary = document.createElement('button');
        btnPrimary.classList.add('btn-primary');
        btnPrimary.textContent = 'Event Detail';
        btnPrimary.onclick = () => {
            window.location.href = `/ActivityPost/Index?id=${event.id}`;
        };

        cardFooter.append(metaInfo, btnPrimary);
        card.append(cardHeader, cardBody, cardFooter);
        container.appendChild(card);
    });

    setTimeout(observeCards, 50);  // observe หลัง render เสร็จ
}

renderCards(eventsData);

// ── Show More ──────────────────────────────────────
document.getElementById('btn-show-more')?.addEventListener('click', function () {
    const items = document.querySelectorAll('.category-item');
    const isHidden = items[0]?.style.display === 'none';
    items.forEach(item => {
        item.style.display = isHidden ? 'flex' : 'none';
    });
    this.textContent = isHidden ? 'Show Less' : 'Show More';
});

// ── AJAX Search ──────────────────────────────────────
let debounceTimer;

document.querySelector('.filter-box input[type="text"]')?.addEventListener('input', () => {
    clearTimeout(debounceTimer);
    debounceTimer = setTimeout(fetchResults, 300);
});

document.getElementById('sort-select')?.addEventListener('change', fetchResults);
document.getElementById('date-select')?.addEventListener('change', fetchResults);
document.getElementById('location-select')?.addEventListener('change', fetchResults);
document.querySelector('.search-button')?.addEventListener('click', fetchResults);

document.querySelectorAll('.status-checkbox').forEach(cb => {
    cb.addEventListener('change', fetchResults);
});

document.querySelectorAll('.checkbox-item input:not(.status-checkbox)').forEach(cb => {
    cb.addEventListener('change', fetchResults);
});

async function fetchResults() {
    const sidebarKeyword    = document.querySelector('.filter-box input[type="text"]')?.value.trim() || '';
    const bannerKeyword     = document.querySelector('.search-input')?.value.trim() || '';
    const keyword           = sidebarKeyword || bannerKeyword;
    const sortBy            = document.getElementById('sort-select')?.value || 'newest';
    const dateRange         = document.getElementById('date-select')?.value || '';
    const checkedStatus     = [...document.querySelectorAll('.status-checkbox:checked')]
                                .map(cb => cb.value).join(',');
    const location          = document.getElementById('location-select')?.value || '';
    const checkedCategories = [...document.querySelectorAll('.checkbox-item input:not(.status-checkbox):checked')]
                                .map(cb => cb.value).join(',');

    const params = new URLSearchParams();
    if (keyword)                     params.set('q', keyword);
    if (checkedCategories)           params.set('categories', checkedCategories);
    if (location && location !== '') params.set('location', location);
    if (sortBy)                      params.set('sortBy', sortBy);
    if (dateRange)                   params.set('dateRange', dateRange);
    if (checkedStatus)               params.set('statusFilter', checkedStatus);

    container.innerHTML = '<p style="color:#9ca3af; padding:24px;">Loading...</p>';

    try {
        const res  = await fetch(`/Home/Search?${params.toString()}`);
        const data = await res.json();
        renderCards(data);
    } catch (err) {
        container.innerHTML = '<p style="color:#ef4444; padding:24px;">Something went wrong.</p>';
    }
}

// Parallax
window.addEventListener('scroll', () => {
    requestAnimationFrame(() => {
        const banner = document.querySelector('.banner');
        if (banner) {
            banner.style.backgroundPositionY = `calc(50% + ${window.scrollY * 0.9}px)`;
        }
    });
});

// ── Scroll Reveal ──────────────────────────────────────
const observer = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('visible');
            observer.unobserve(entry.target);
        }
    });
}, { threshold: 0.1 });

// observe sidebar ที่อยู่คงที่
document.querySelectorAll('.filter-box, .ad-banner').forEach(el => {
    observer.observe(el);
});

// observe cards — เรียกซ้ำได้หลัง renderCards
function observeCards() {
    document.querySelectorAll('.event-card:not(.visible)').forEach(el => {
        observer.observe(el);
    });
}

observeCards();