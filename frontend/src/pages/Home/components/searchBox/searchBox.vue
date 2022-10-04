<template> 

    <div class="searchArea">

        <div class="searchBox">
            <form action="https://localhost:7032/api/Ads" method="get">
                <input type="text" name="q" placeholder="O que você procura?">
                <select name="state" v-model="stateEscolhido" >
                    <option v-for="(state, index) in states" :key="index" :value="state.StatesId">{{state.Nome}}</option>
                </select>
                <button>Pesquisar</button>
            </form>
        </div>

        <div class="categoryList" >
            <div class="categoryItem" v-for="(categoria, index) in categorias" :key="index">
                <a href="" >
                    <img :src="`data:image/png;base64,${categoria.Slug}`" alt="">
                    <span>{{categoria.Nome}}</span>
                </a>
            </div>
        </div>
    </div>

</template>

<script>
    import { useStore } from 'vuex';
    import { computed, ref } from 'vue';
    export default {
        setup() {

            const store = useStore();

            const states = computed(() => {
                return store.state.users.stateLoc;
            })

            const stateEscolhido = ref('');

            const categorias = computed(() => {
                return store.state.users.categorias;
            })

            return {
                states,
                stateEscolhido,
                categorias
            }
        }
    }
</script>

<style scoped>
    .searchArea {
        border-bottom: 1px solid #ccc;
        background-color: #ddd;
        padding: 20px 0;
    }
    .searchBox {
        background-color: #9BB83C;
        padding: 20px 15px;
        border-radius: 5px;
        box-shadow: 1px 1px 1px 0.3 rgba(0, 0, 0, 0.2);
        display: flex;
    }
    .searchBox form {
        flex: 1;
        display: flex;

    }
    .searchBox form input, .searchBox form select {
        height: 40px;
        border: 0;
        border-radius: 5px;
        outline: 0;
        font-size: 15px;
        color: #000;
        margin-right: 20px;
    }

    input {
        flex: 1;
        padding: 0 10px;
    }
    button {
        background-color: #49aeef;
        font-size: 15px;
        border: 0;
        border-radius: 5px;
        color: #fff;
        height: 40px;
        padding: 0;
        cursor: pointer;
    }

    .categoryList {
        display: flex;
        flex-wrap: wrap;
        margin-top: 20px;
    }
    .categoryList .categoryItem {
        width: 25%;
        display: flex;
        align-items: center;
        color: #000;
        text-decoration: none;
        height: 50px;
        margin-bottom: 10px;

    }

    .categoryItem:hover {
        color: #999
    }
    .categoryItem img {
        width: 45px;
        height: 45px;
        margin-right: 10px;
    }
</style>