<template>
    <div class="container">
        <h1 class="pagetitle">Cadastro</h1>
            <form @submit.prevent="signup">
                <label class="area">
                    <div class="area--title">Nome</div>
                    <div class="area--input">
                        <input type="text"
                        :disabled="disabled"
                        v-model="name" 
                        required>                        
                    </div>
                </label>
                <label class="area">
                    <div class="area--title">Estado</div>
                        <div class="area--input">
                            <select v-model="selectedState">
                                    <option value="ac">Acre</option> 
                                    <option value="al">Alagoas</option> 
                                    <option value="am">Amazonas</option> 
                                    <option value="ap">Amapá</option> 
                                    <option value="ba">Bahia</option> 
                                    <option value="ce">Ceará</option> 
                                    <option value="df">Distrito Federal</option> 
                                    <option value="es">Espírito Santo</option> 
                                    <option value="go">Goiás</option> 
                                    <option value="ma">Maranhão</option> 
                                    <option value="mt">Mato Grosso</option> 
                                    <option value="ms">Mato Grosso do Sul</option> 
                                    <option value="mg">Minas Gerais</option> 
                                    <option value="pa">Pará</option> 
                                    <option value="pb">Paraíba</option> 
                                    <option value="pr">Paraná</option> 
                                    <option value="pe">Pernambuco</option> 
                                    <option value="pi">Piauí</option> 
                                    <option value="rj">Rio de Janeiro</option> 
                                    <option value="rn">Rio Grande do Norte</option> 
                                    <option value="ro">Rondônia</option> 
                                    <option value="rs">Rio Grande do Sul</option> 
                                    <option value="rr">Roraima</option> 
                                    <option value="sc">Santa Catarina</option> 
                                    <option value="se">Sergipe</option> 
                                    <option value="sp">São Paulo</option> 
                                    <option value="to">Tocantins</option> 

                            </select>
                    </div>
                </label>            
                <label class="area">
                    <div class="area--title">Email</div>
                    <div class="area--input">
                        <input type="email"
                        :disabled="disabled"
                        v-model="email" 
                        required>                        
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
                    <div class="area--title">Confirmar senha</div>
                    <div class="area--input">
                        <input type="password"                         
                        :disabled="disabled"
                        v-model="confirmPassword"
                        required>                        
                    </div>
                </label>
                <label class="area">
                    <div class="area--title"></div>
                    <div class="area--input">
                        <button type="submit">Fazer cadastro</button>   
                    </div>
                </label>

                <div v-if="password != confirmPassword" class="erro">Senhas não conferem</div>

                <div v-if="erro" class="erro">{{erro}}</div>
            </form>
    </div>
</template>

<script>

import  {ref} from 'vue'
import {useStore} from 'vuex'

export default {
    name: 'LoginVue',
    setup(){
        const store = useStore()
        const erro = ref('');
        const name = ref('');
        const email = ref("")
        const password = ref("")
        const confirmPassword = ref("");
        const disabled = ref(store.state.users.user.disabled)
        const selectedState = ref('Selecione o Estado')      

        const signup = async () => {
            if(password.value !== confirmPassword.value) {
                return;
            }
            else {
                await store.commit('SET_USER', {
                    email: email.value,
                    password: password.value,
                    name: name.value,
                    disabled: disabled.value,
                    state: selectedState.value                
                })
                const auth = await store.dispatch('register', {
                    name: name.value,
                    email: email.value,
                    password: password.value,
                    stateLoc: selectedState.value
                }).then(() => {             
                    store.commit('SET_DISABLED', true);             
                }).catch(error => {
                    store.dispatch('setarErro', error);
                    erro.value = error;
                    store.commit('SET_DISABLED', false);
            })
                return auth;
            }
        }

            /*store.dispatch('auth', {
                email: email.value,
                password: password.value
            })
            .then((response) => {
                console.log(response);
            }).catch(error => {
                store.dispatch('setarErro', error)
            })*/
            //const json = await api.login(email.value, password.value);

            //if(json.error) {
               // console.log('erro');
            //} else {
                //doLogin(json.token, rememberPassword);
              //  this.router.push('/');
            //}
    return {
        erro,
        email,
        password,
        name,
        confirmPassword,
        disabled,
        store,
        selectedState,
        signup
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