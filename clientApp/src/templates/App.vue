<template>
  <div class="page-container">
    <md-app md-waterfall md-mode="fixed-last">
      <md-app-toolbar class="md-large md-dense md-primary">
        <div class="md-toolbar-row">
          <div class="md-toolbar-section-start">
            <!-- <md-button class="md-icon-button" @click="menuVisible = !menuVisible">
              <md-icon>menu</md-icon>
            </md-button> -->

            <span class="md-title">Company Name</span>
          </div>

          <!-- <div class="md-toolbar-section-end">
            <md-button class="md-icon-button">
              <md-icon>more_vert</md-icon>
            </md-button>
          </div> -->
        </div>

        <div class="md-toolbar-row">
          <md-tabs class="md-primary">
            <md-tab id="tab-home" md-label="Home" to="/Home"></md-tab>
            <md-tab id="tab-about" md-label="About" to="/about"></md-tab>
            <md-tab id="tab-calculators-mortgage" md-label="Mortgage Calculator" to="/calculators/mortgage"></md-tab>
            <!-- <md-tab id="tab-calculators-investment" md-label="Investment Calculator" to="/calculators/investment"></md-tab> -->
            <!-- <md-tab id="tab-pages" md-label="Pages"></md-tab>
            <md-tab id="tab-posts" md-label="Posts"></md-tab>
            <md-tab id="tab-favorites" md-label="Favorites"></md-tab> -->
          </md-tabs>
        </div>
      </md-app-toolbar>

      <!-- <md-app-drawer :md-active.sync="menuVisible">
        <md-toolbar class="md-transparent" md-elevation="0">Navigation</md-toolbar>

        <md-list>
          <md-list-item>
            <md-icon>move_to_inbox</md-icon>
            <span class="md-list-item-text">Inbox</span>
          </md-list-item>

          <md-list-item>
            <md-icon>send</md-icon>
            <span class="md-list-item-text">Sent Mail</span>
          </md-list-item>

          <md-list-item>
            <md-icon>delete</md-icon>
            <span class="md-list-item-text">Trash</span>
          </md-list-item>

          <md-list-item>
            <md-icon>error</md-icon>
            <span class="md-list-item-text">Spam</span>
          </md-list-item>
        </md-list>
      </md-app-drawer> -->

      <md-app-content>
        <slot />
      </md-app-content>
    </md-app>
  </div>
</template>

<script>
export default {
  name: 'AppTemplate',
  data: () => ({
    menuVisible: false
  })
}
</script>

<style lang="scss" scoped>
  .md-app {
    // max-height: 400px;
    // border: 1px solid rgba(#000, .12);
    height: 100vh;
  }

  //  // Demo purposes only
  // .md-drawer {
  //   width: 230px;
  //   max-width: calc(100vw - 125px);
  // }
</style>
