<template>
    <div>
        <HeaderVue/>
        <router-view></router-view>
        <FooterVue/>
    </div>
</template>

<script>
import HeaderVue from './components/HeaderVue.vue'
import FooterVue from './components/FooterVue.vue'
export default {
    components: {
        HeaderVue,
        FooterVue
    },
    created() {
        this.$store.dispatch("users/categorias");
        this.$store.dispatch("users/states")
        this.$store.dispatch("ads/getADS");
        if (this.$store.state.users.user == undefined) {
            var usuario = JSON.parse(localStorage.getItem("usuario"));
            if(usuario !== null) {
                this.$store.dispatch("users/login", usuario);
            }
        }
    },
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@300;500&family=Open+Sans:ital,wght@0,500;1,300;1,500&display=swap');

body{
    margin: 0;
    font-family: 'Open Sans', sans-serif;

}

.container{
    max-width: 1000px;
    margin: auto;
}

* {
    box-sizing: border-box;
}

</style>