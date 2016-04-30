function vote(id, returnUrl) {
    fetch("/Cart/AddToCart", {
            method: "post",
            headers: { "Content-Type": "application/x-www-form-urlencoded" },
            body: "id=" + id + "&returnUrl=" + returnUrl,
            credentials: "same-origin"
        })
        .then(function (data) {
            fetch("/Cart/Cart", {
                    credentials: 'same-origin'
                })
                .then(function (partialViewResult) {
                    return partialViewResult.text();
                })
                .then(function(text) {
                    document.querySelector("#cart-root").innerHTML = text;
                });
        });
}

function unvote(id, returnUrl) {
    //RemoveFromCart
    fetch("/Cart/RemoveFromCart", {
        method: "post",
        headers: { "Content-Type": "application/x-www-form-urlencoded" },
        body: "id=" + id + "&returnUrl=" + returnUrl,
        credentials: "same-origin"
    })
        .then(function (data) {
            fetch("/Cart/Cart", {
                credentials: 'same-origin'
            })
                .then(function (partialViewResult) {
                    return partialViewResult.text();
                })
                .then(function (text) {
                    document.querySelector("#cart-root").innerHTML = text;
                });
        });
}