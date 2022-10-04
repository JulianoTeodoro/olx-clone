<template>
    <div class="header">
        <div class="container">
            <div class="logo">
                <router-link to="/">
                    <span class="logo-1">O</span>
                    <span class="logo-2">L</span>
                    <span class="logo-3">X</span>                    
                </router-link>
            </div>
            <nav>
                <ul v-if="logged">
                    <li>
                        <router-link to="/myaccount">Minha conta</router-link>
                    </li>
                    <li>
                        <router-link to="/post-an-ad" class="button">Poste um anúncio</router-link>
                    </li>
                    <li>
                        <router-link to="/" @click="handleLogout">Sair</router-link>
                    </li>
                </ul>
                <ul v-else>
                    <li>
                        <router-link to="/signin">Login</router-link>
                    </li>
                    <li>
                        <router-link to="/signup">Cadastrar</router-link>
                    </li>
                                        
                </ul>
            </nav>
        </div>

    </div>

</template>

<script>

import { isLogged, doLogout } from '@/helpers/authHandler'

export default {
    setup(){

        const logged = isLogged();
        const handleLogout = () => {
            doLogout();
            
        }

        return {
            logged,
            handleLogout
        }
    }
}
</script>

<style scoped>

    .header {
        background-color: #FFF;
        height: 60px;
        border-bottom: 1px solid #ccc;
    }
    
    .container{
        max-width: 1000px;
        margin: auto;
        display: flex;
    }

    a{
        text-decoration: none;
    }

    .logo{
        flex: 1;
        display: flex;
        align-items: center;
        height: 60px;
    }
    .logo-1, .logo-2, .logo-3{
        font-size: 27px;
        font-weight: bold;
    }

    .logo-1{
        color: #FF0000;
    }

    .logo-2{
        color: #00FF00;
    }

    .logo-3{
        color: #0000FF
    }

    nav{
        padding-top: 10px;
        padding-bottom: 10px;
    }

    nav ul, nav li{
        margin: 0;
        padding: 0;
        list-style: none
    }

    ul {
        display: flex;
        align-items: center;
        height: 40px;
    }

    nav li {
        margin-left: 20px;
        margin-right: 20px;
        
    }

    li a {
        color: #000;
        font-size: 14px;
        text-decoration: none;

    }
    .sair {
        background-color: #000
    }

    li a:hover{
        color: #333;
    }

    .button{
        background-color: #FF8100;
        border-radius: 4px;
        color: #FFF;
        padding: 5px 10px;
    }

    .button:hover{
        background-color: #E57706;
    }

</style>