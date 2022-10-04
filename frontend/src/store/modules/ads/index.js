import OlxAPI from '@/helpers/OlxAPI'
const api = OlxAPI();

export default {
    namespaced: true,
    state: {
        ads: undefined
    },
    mutations: {
        SET_ADS: (state, ads) => {
            state.ads = ads;
        }
    },
    actions: {
        async getADS({commit}) {
            const json = await api.ads();
            if(json.error) {
                console.log(json.error);
            }
            else {
                commit("SET_ADS", json)
            }
        }
    }
}