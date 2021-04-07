var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        objectIndex: 0,
        price: 0,
        productModel: {
            id: 0,
            name: "name",
            description: "desc",
            value: 2.22,
        },
        products: []
    },

    methods: {
        getProduct(id) {
            this.loading = true;
            axios.get("/Admin/Home/GetProduct/" + id)
                .then(res => {
                    console.log(res);
                    console.log(res.data.id);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
                
        },
        getProducts() {
            this.loading = true;
            axios.get("/Admin/Home/GetAll")
                .then(res => {
                    console.log(res);
                    console.log(res.data.id);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });

        },
        createProduct() {
            this.loading = true;

            axios.post("/admin/home/create", this.productModel)
                .then(res => {
                    console.log(res.data);
                    this.products.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateProduct() {
            this.loading = true;

            axios.put("/admin/home/edit", this.productModel)
                .then(res => {
                    console.log(res.data);
                    console.log('-------');
                    console.log(this.objectIndex);
                    this.products.splice(this.objectIndex, 1, res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        deleteProduct(id, index) {
            this.loading = true;
            axios.delete("/Admin/Home/Delete/" + id)
                .then(res => {
                    this.products.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });

        },
        editProduct(product, index) {
            this.objectIndex = index;
            this.productModel = {
                id: product.id,
                name: product.name,
                description: product.description,
                value: product.value,
            };
        }
    },


    computed: {

    }
})