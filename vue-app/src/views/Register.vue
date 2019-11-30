<template>
    <div>
        <ValidationObserver v-slot="{ handleSubmit }">
            <el-form
                @submit.native.prevent="handleSubmit(register)"
                class="form-register"
                :label-position="'top'"
                label-width="100px"
                :model="formRegister"
            >
                <h1>Register</h1>

                <el-row :gutter="10">
                    <el-col :sm="24" :md="12" class="grid-content">
                        <el-form-item label="Name">
                            <validation-provider
                                name="Name"
                                rules="required|alpha"
                                v-slot="{ errors }"
                            >
                                <el-input
                                    v-model="formRegister.name"
                                    type="text"
                                    placeholder="Enter your name"
                                ></el-input>
                                <span>{{ errors[0] }}</span>
                            </validation-provider>
                        </el-form-item>
                    </el-col>

                    <el-col :sm="24" :md="12" class="grid-content">
                        <el-form-item label="Surname">
                            <validation-provider
                                name="Surname"
                                rules="required|alpha"
                                v-slot="{ errors }"
                            >
                                <el-input
                                    v-model="formRegister.surname"
                                    placeholder="Enter your surname"
                                ></el-input>
                                <span>{{ errors[0] }}</span>
                            </validation-provider>
                        </el-form-item>
                    </el-col>
                </el-row>

                <el-row :gutter="10">
                    <el-col :sm="24" :md="12" class="grid-content">
                        <el-form-item label="Email Address">
                            <validation-provider
                                name="Email Address"
                                rules="required|email"
                                v-slot="{ errors }"
                            >
                                <el-input
                                    type="email"
                                    v-model="formRegister.emailAddress"
                                    placeholder="Enter your Email Address"
                                ></el-input>
                                <span>{{ errors[0] }}</span>
                            </validation-provider>
                        </el-form-item>
                    </el-col>

                    <el-col :sm="24" :md="12" class="grid-content">
                        <el-form-item label="Username">
                            <validation-provider
                                name="Username"
                                rules="required"
                                v-slot="{ errors }"
                            >
                                <el-input
                                    v-model="formRegister.userName"
                                    placeholder="Enter your Username"
                                ></el-input>
                                <span>{{ errors[0] }}</span>
                            </validation-provider>
                        </el-form-item>
                    </el-col>
                </el-row>

                <el-row :gutter="10">
                    <el-col :sm="24" :md="12" class="grid-content">
                        <el-form-item label="Password">
                            <validation-provider
                                name="Password"
                                rules="required"
                                v-slot="{ errors }"
                                vid="password"
                            >
                                <el-input
                                    type="password"
                                    v-model="formRegister.password"
                                    placeholder="Enter your Password"
                                ></el-input>
                                <span>{{ errors[0] }}</span>
                            </validation-provider>
                        </el-form-item>
                    </el-col>

                    <el-col :sm="24" :md="12" class="grid-content">
                        <el-form-item label="Confirm Password">
                            <validation-provider
                                name="Confirm Password"
                                rules="required|confirmed:password"
                                v-slot="{ errors }"
                            >
                                <el-input
                                    type="password"
                                    v-model="formRegister.confirmPassword"
                                    placeholder="Confirm your Password"
                                ></el-input>
                                <span>{{ errors[0] }}</span>
                            </validation-provider>
                        </el-form-item>
                    </el-col>
                </el-row>

                <div class>
                    <el-button type="primary" native-type="submit" class>Register</el-button>
                </div>
                <p class>© 2017-2019</p>
            </el-form>
        </ValidationObserver>
    </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { Action } from 'vuex-class'
import { RegisterAccount } from '../types/userModel'
import { ValidationObserver, ValidationProvider } from 'vee-validate';

@Component({
    name: 'Register',
    components: {
        ValidationObserver,
        ValidationProvider
    }
})
export default class Register extends Vue {
    public formRegister: any = {
        name: '',
        surname: '',
        emailAddress: '',
        userName: '',
        password: '',
        confirmPassword: ''
    }
    @Action('register', { namespace: 'AppModule' })
    public actionRegister!: (formRegister: RegisterAccount) => Promise<any>

    public async register() {
        const data = {
            name: this.formRegister.name,
            surname: this.formRegister.surname,
            emailAddress: this.formRegister.emailAddress,
            userName: this.formRegister.userName,
            password: this.formRegister.password,
        }
        const response = await this.actionRegister(data)
    }
}
</script>

<style lang="scss" scoped>
.form-register {
    width: 100%;
    max-width: 800px;
    margin: auto;
}
</style>