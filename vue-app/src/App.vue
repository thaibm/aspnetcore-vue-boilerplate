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
            <el-menu-item index="3" @click="logout" v-if="isAuthenticated">Logout</el-menu-item>
            <el-menu-item index="3" v-else :route="{name:'login'}">Login</el-menu-item>
        </el-menu>
        <router-view />
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { Action, Getter } from 'vuex-class'

@Component({
    name: 'App'
})
export default class App extends Vue {
    public activeIndex: string = '1';

    @Getter('isAuthenticated', { namespace: 'AppModule' })
    public isAuthenticated!: boolean;

    @Action('logout', { namespace: 'AppModule' })
    public actionLogout!: () => Promise<any>;

    public mounted() {
    }

    public async logout() {
        const result = await this.actionLogout();
        this.$router.push("/login");
    }
}
</script>
<style lang="scss">
</style>
