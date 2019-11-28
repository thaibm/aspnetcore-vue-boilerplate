<template>
    <div class="login-page">
        <el-form
            @submit.native.prevent="login"
            class="form-login"
            :label-position="'top'"
            label-width="100px"
            :model="formLogin"
        >
            <div class="logo-vue">
                <img alt="Vue logo" src="../assets/logo.png" />
            </div>
            <h1 class="h3 mb-3 font-weight-normal">Please login</h1>
            <el-form-item>
                <el-input
                    v-model="formLogin.usernameOrEmailAddress"
                    placeholder="Enter your Username Or EmailAddress"
                    required
                ></el-input>
            </el-form-item>
            <el-form-item>
                <el-input
                    type="password"
                    v-model="formLogin.password"
                    placeholder="Enter your Password"
                    required
                ></el-input>
            </el-form-item>
            <p>Don't have an account? <a href="/register">Register</a></p>
            <el-button type="primary" native-type="submit" class="btn-block">Login</el-button>
            <p class="mt-5 mb-3 text-muted text-center">© 2017-2019</p>
        </el-form>
    </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { Action } from 'vuex-class/lib';

@Component({
    name: 'Login',
})
export default class Login extends Vue {
    public formLogin: any = {
        usernameOrEmailAddress: '',
        password: ''
    };

    @Action('login', { namespace: 'AppModule' })
    public actionLogin!: (data: any) => Promise<any>;

    public async login() {
        let usernameOrEmailAddress = this.formLogin.usernameOrEmailAddress;
        let password = this.formLogin.password;

        try {
            const response = await this.actionLogin({ usernameOrEmailAddress, password });
            this.$router.push('/')
        } catch (error) {
            console.error(error);
        }
    }
}
</script>

<style lang="scss" scoped>
.login-page {
    display: flex;
    align-items: center;
    height: 100vh;
}

.form-login {
    width: 100%;
    max-width: 330px;
    padding: 1rem;
    margin: auto;
    text-align: center;

    .logo-vue {
        text-align: center;
        padding-bottom: 2rem;

        img {
            max-width: 7.5rem;
        }
    }
}
</style>