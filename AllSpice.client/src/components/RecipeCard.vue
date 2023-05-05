<template>
  <div class="p-2 rounded" @click="viewRecipe()">
    <div class="recipe-card rounded position-relative elevation-2"
      :style="{ 'background-image': 'url(' + recipe.img + ')' }">

      <i class="mdi mdi-heart-outline align-self-right fuzzy-bg text-light"></i>

    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState.js';
import { Recipe } from '../models/Recipe.js';

export default {
  props: { recipe: { type: Recipe, required: true } },
  setup(props) {
    function clearActive(event) {

    }
    return {
      viewRecipe() {
        AppState.activeRecipe = props.recipe
      }
      // $('#modalId').on('hidden.bs.modal',clearActive(e))
    }
  }
}
</script>


<style lang="scss" scoped>
.recipe-card {
  height: 27vh;
  width: 100%;
  background-position: center;
  background-size: cover;
}

.fuzzy-bg {
  // box-shadow: 0 0 2px rgb(18 16 16 / 35%);
  // backdrop-filter: drop-shadow(4px 4px rgb(18 16 16 / 35%));
  background-color: rgb(18 16 16 / 35%);
  border-radius: 30%;
  backdrop-filter: blur(30px);
  position: absolute;
  top: 5px;
  right: 5px;
}
</style>