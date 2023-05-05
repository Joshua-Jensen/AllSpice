<template>
  <section class="row">
    <div class="col-4 img-col position-relative" :style="{ 'background-image': 'url(' + recipe.img + ')' }">
      <i class="mdi mdi-heart-outline align-self-right fuzzy-bg text-light"></i>

    </div>
    <div class="col-8">
      <section class="row">
        <div class="col-12"></div>
        <div class="col-6"></div>
        <div class="col6"></div>
      </section>
    </div>
  </section>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

export default {
  props: { recipe: { type: Recipe, required: true } },
  setup() {
    return {
      recipe: computed(() => AppState.activeRecipe)
    }
  }
}
</script>


<style lang="scss" scoped>
.img-col {
  height: 100%;
  background-position: center;
  background-size: cover;
}

.fuzzy-bg {
  background-color: rgb(18 16 16 / 35%);
  border-radius: 30%;
  backdrop-filter: blur(30px);
  position: absolute;
  top: 5px;
  right: 5px;
}
</style>