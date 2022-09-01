<template>
    <div class="container">
        <h1 class="pagetitle">Login</h1>
            <form @submit.prevent="signin">
                <label class="area">
                    <div class="area--title">Email</div>
                    <div class="area--input">
                        <input type="email"
                        :disabled="disabled"
                        v-model="email">                        
                    </div>
                </label>
                <label class="area">
                    <div class="area--title">Senha</div>
                    <div class="area--input">
                        <input type="password"                         
                        :disabled="disabled"
                        v-model="password"
                        required>                        
                    </div>
                </label>
                <label class="area">
                    <div class="area--title">Lembrar senha</div>
                    <div class="area--input">
                        <input type="checkbox"           
                        v-model="rememberPassword"
                        @change="store.commit('users/SET_REMEMBER_PASSWORD', rememberPassword)"
                        :disabled="disabled">                        
                    </div>
                </label>
                <label class="area">
                    <div class="area--title"></div>
                    <div class="area--input">
                        <button type="submit">Entrar</button>   
                    </div>
                </label>
                <div v-if="erro" class="erro">{{erro}}</div>

            </form>

    </div>
</template>

<script>

import {ref} from 'vue'
import { useStore } from 'vuex';

export default {
    name: 'LoginVue',
    setup(){
        const store = useStore()
        const erro = ref('');
        const email = ref("")
        const password = ref("")
        const rememberPassword = ref(false)
        const disabled = ref(false)
        
        const signin = () => {
            
            disabled.value = true;

            store.dispatch('users/login', {
                email: email.value,
                password: password.value
            }).then(() => {
                store.commit('users/SET_USER', {
                    email: email.value,
                    password: password.value,
                    disabled: disabled.value                
                })
            }).catch(error => {
                store.dispatch('setarErro', error);
                erro.value = error;
            })
            .finally(() => disabled.value = false)
        }

    return {
        signin, 
        erro,
        email,
        password,
        rememberPassword,
        disabled,
        store,
    }
    },
}

</script>

<style scoped>

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