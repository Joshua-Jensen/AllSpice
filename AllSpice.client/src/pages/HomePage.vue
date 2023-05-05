<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-3 p-2" v-for="r in recipes">
        <RecipeCard :recipe="r" />
      </div>
    </section>
    <Modal>
      <slot name="title" v-if="activeRecipe.id">
      </slot>
      <slot name="body" v-if="activeRecipe.id">
        <RecipeDetailsModal />
      </slot>
    </Modal>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js'
import Modal from '../components/Modal.vue.js';
import RecipeDetailsModal from '../components/RecipeDetailsModal.vue.js';

export default {
  setup() {
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      }
      catch (error) {
        Pop.error(error);
        logger.log(error);
      }
    }
    onMounted(() => {
      getRecipes();
    });
    return {
      activeRecipe: computed(() => AppState.activeRecipe),
      recipes: computed(() => AppState.recipes),
      viewRecipe(recipe) {
      }
    };
  },
  components: { Modal, Modal, RecipeDetailsModal }
}
</script>

<style scoped lang="scss"></style>
