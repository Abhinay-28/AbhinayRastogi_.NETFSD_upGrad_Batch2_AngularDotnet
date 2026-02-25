// ---------------- DATA MODULE ----------------
const products = [
    { id:1, name:"Laptop" },
    { id:2, name:"Mobile Phone" },
    { id:3, name:"Headphones" },
    { id:4, name:"Smart Watch" },
    { id:5, name:"Keyboard" },
    { id:6, name:"Mouse" }
];


// ---------------- DOM REFERENCES ----------------
const searchInput = document.getElementById("searchInput");
const productList = document.getElementById("productList");


// ---------------- RENDER MODULE ----------------
const renderProducts = (items) => {

    if(items.length === 0){
        productList.innerHTML =
            `<p class="no-result">No Results Found</p>`;
        return;
    }

    productList.innerHTML = items.map(product => `
        <div class="product" data-id="${product.id}">
            ${product.name}
        </div>
    `).join("");
};


// ---------------- FILTER MODULE ----------------
const filterProducts = (keyword) => {

    const filtered = products.filter(product =>
        product.name.toLowerCase()
        .includes(keyword.toLowerCase())
    );

    renderProducts(filtered);
};


// ---------------- EVENT MODULE ----------------

// Dynamic filtering while typing
searchInput.addEventListener("input", (e)=>{
    filterProducts(e.target.value);
});


// Event Delegation (future scalability)
productList.addEventListener("click",(e)=>{

    const productCard = e.target.closest(".product");

    if(!productCard) return;

    const id = productCard.dataset.id;

    console.log(`Product clicked: ${id}`);
});


// Initial Load
renderProducts(products);