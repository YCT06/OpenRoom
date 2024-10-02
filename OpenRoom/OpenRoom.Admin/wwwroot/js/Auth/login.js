//IIFE�O�ߧY����禡�A���Q��b�̭��Awindow�ݤ���
(function IIFE() {
    const HOME_PAGE = '/Home/Dashboard'
    const api = { login: '/api/Auth/Login' }
    const apiCaller = { login: (loginQuery) => httpPost(api.login, loginQuery) }

    const authLoginVue = Vue.createApp({
        data(){
            return {
                login: {
                    userName: '',
                    password: ''
                }
            }
        },
        methods: {
            loginBtn() {
                //handleLogin({ ...this.login })//���handleLogin�|����username��password
                //handleLogin({
                //    userName: this.login.userName,
                //    password: this.login.password
                //})
                handleLogin(this.login)

            }
        }
    })
    
    authLoginVue.mount('#authLogin')
    function handleLogin(loginQuery) {
        apiCaller.login(loginQuery)
            .then((res) => {
                console.log(res)

                const { token, expireTime } = res
                setToken(token)
                   
                redirectToHome()
                
            })
            .catch(err => {
                console.error(err)
            })
    }
    //body�Obaseapi��body
    function setToken(token) {
        localStorage.setItem('token', token)
    }

    function redirectToHome() {
        window.location.href = HOME_PAGE
    }
})()