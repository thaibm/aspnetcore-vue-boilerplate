<template>
    <div id="app">
        <el-menu
            :default-active="activeIndex"
            class="el-navbar"
            mode="horizontal"
            v-if="isAuthenticated"
            :router="true"
        >
            <el-menu-item index="1" :route="{name:'home'}">Home</el-menu-item>
            <el-menu-item index="2" :route="{name:'about'}">About</el-menu-item>
            <el-submenu index="3" v-if="isAuthenticated">
                <template slot="title">{{userDetails.name}}</template>
                <el-menu-item index="2-1">Profile</el-menu-item>
                <el-menu-item index="2-2" @click="logout">Logout</el-menu-item>
            </el-submenu>
            <el-menu-item index="3" v-else :route="{name:'login'}">Login</el-menu-item>
        </el-menu>
        <router-view />
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { Action, Getter } from 'vuex-class'
import { UserDetails } from './types/userModel'

@Component({
    name: 'App'
})
export default class App extends Vue {
    public activeIndex: string = '1'

    @Getter('isAuthenticated', { namespace: 'AppModule' })
    public isAuthenticated!: boolean
    @Getter('userDetails', { namespace: 'AppModule' })
    public userDetails!: UserDetails

    @Action('logout', { namespace: 'AppModule' })
    public actionLogout!: () => Promise<any>

    @Action('getCurrentLoginInformations', { namespace: 'AppModule' })
    actionGetCurrentLoginInformations!: () => Promise<any>

    public mounted() {
        if (this.isAuthenticated) {
            const response = this.actionGetCurrentLoginInformations()
        }
    }

    public async logout() {
        const result = await this.actionLogout()
        this.$router.push("/login")
    }
}
</script>
<style lang="scss">
</style>
