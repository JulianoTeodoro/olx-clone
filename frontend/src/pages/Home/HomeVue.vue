<template>
    <div>
        <h1>Home</h1>

        <router-link to="/sobre">Sobre</router-link>
        <searchBoxVue />
    </div>


</template>

<script>
    import searchBoxVue from './components/searchBox/searchBox.vue'; 
    export default {
        components: {
            searchBoxVue
        }
    }
</script>

<style scoped>

    *{
        background-color: beige;
    }
    .erro {
        margin: 10px;
        background-color: #FFCACA;
        color: #000;
        border: 2px solid #FF0000;
        padding: 10px
    }

    .area{
        display: flex;
        align-items: center;
        padding: 10px;
        max-width: 500px;
    }

    .area--title{
        width: 200px;
        text-align: right;
        padding-right: 20px;
        font-weight: bold;
        font-size: 14px;
    }
    .area--input{
        flex: 1;

    }
    .area--input input {
        width: 100%;
        font-size: 14px;
        padding: 5px;
        border: 1px solid #ddd;
        border-radius: 3px;
        outline: 0;
        transition: all ease .4s;
    }

    .area--input input:hover{
        border: 1px solid #333;
        color: #333;
    }

    .area--input input[type="checkbox"]{
        float: left;
        width: 10%;

    }

    button {
        background-color: #0089FF;
        border: 0;
        outline: 0;
        padding: 5px 10px;
        border-radius: 4px;
        color: #FFF;
        font-size: 15px;
        cursor: pointer;
    }

    button:hover{
        background-color: #006FCE;
    }

    form{
        background-color: #FFF;
        border-radius: 3px;
        padding: 10px;
        box-shadow: 0px 0px 3px #999;
    }
</style>