<template>
    <div>
        <el-form
            @submit.native.prevent="register"
            class="form-register"
            :label-position="'top'"
            label-width="100px"
            :model="formRegister"
        >
            <div class="logo-vue">
                <img alt="Vue logo" src="../assets/logo.png" />
            </div>
            <h1 class="h3 mb-3 font-weight-normal">Register</h1>
            <el-form-item label="Name">
                <el-input v-model="formRegister.name" placeholder="Enter your name" required></el-input>
            </el-form-item>
            <el-form-item label="Surname">
                <el-input v-model="formRegister.surname" placeholder="Enter your surname" required></el-input>
            </el-form-item>
            <el-form-item label="Email">
                <el-input
                    type="email"
                    v-model="formRegister.email"
                    placeholder="Enter your email"
                    required
                ></el-input>
            </el-form-item>
            <el-form-item label="Username">
                <el-input v-model="formRegister.surname" placeholder="Enter your username" required></el-input>
            </el-form-item>
            <el-form-item label="Password">
                <el-input
                    type="password"
                    v-model="formRegister.password"
                    placeholder="Enter your Password"
                ></el-input>
            </el-form-item>
            <el-form-item label="Confirm Password">
                <el-input
                    type="password"
                    v-model="formRegister.confirmPassword"
                    placeholder="Confirm your Password"
                ></el-input>
            </el-form-item>
            <el-button type="primary" native-type="submit" class="btn-block">Register</el-button>
            <p class="mt-5 mb-3 text-muted text-center">© 2017-2019</p>
        </el-form>
    </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'

@Component({
    name: 'Register',
})
export default class Register extends Vue {
    public formRegister: any = {
        name: '',
        surname: '',
        email: '',
        username: '',
        password: '',
        confirmPassword: ''
    }

    public register() {

    }
}
</script>

<style lang="scss" scoped>
.form-register {
    width: 100%;
    max-width: 330px;
    padding: 1rem;
    margin: auto;

    .logo-vue {
        text-align: center;
        padding-bottom: 2rem;

        img {
            max-width: 7.5rem;
        }
    }
}
</style>