window.showLink = (link) => {
    const binString = atob(link);
    const url = new URL(binString);
    const linkModal = document.getElementById('linkModal');
    
    const bsModal = new bootstrap.Modal(linkModal);

    linkModal.querySelector('#fullUrl').textContent = binString

    linkModal.querySelector('#url_protocol').textContent = url.protocol

    linkModal.querySelector('#url_user').textContent = url.username
    linkModal.querySelector('#url_password').textContent = url.password

    linkModal.querySelector('#url_host').textContent = url.host

    linkModal.querySelector('#url_port').textContent = url.port

    linkModal.querySelector('#url_path').textContent = url.pathname

    linkModal.querySelector('#url_query').textContent = url.search

    linkModal.querySelector('#url_hash').textContent = url.hash

    bsModal.show();
};