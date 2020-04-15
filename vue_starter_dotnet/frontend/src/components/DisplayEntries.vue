<template>
   <div>
-        <form v-for="food in meals" :key="food.mealID" v-on:submit.prevent="removeEntry(food.mealID)">
+    <div v-for="food in meals" :key="food.mealID">
         <h5>{{food.foodName}}</h5>
-        <button type="submit">Remove Entry</button>
+        <button v-on:click="removeEntry(food.mealID)" type="submit" >Remove Entry</button>
+        <button v-on:click="isHidden == false" type="submit" >Edit Entry</button>
+        <form v-on:submit.prevent="editEntry(food)">
+            <select v-model="food.mealType">
+                <span>Select meal type:</span>
+                <option selected disabled value="">Please select one</option>
+                <option>Breakfast</option>
+                <option>Lunch</option>
+                <option>Dinner</option>
+                <option>Snack</option>
+            </select>
+            <select v-model="food.servings">
+                <span>Select meal type:</span>
+                <option selected disabled value="">Please select one</option>
+                <option>0.5</option>
+                <option>1</option>
+                <option>1.5</option>
+                <option>2</option>
+                <option>2.5</option>
+                <option>3</option>
+                <option>3.5</option>
+                <option>4</option>
+                <option>4.5</option>
+                <option>5</option>
+            </select>
+            <button v-on:submit.prevent="editEntry(food)" type="submit" >Edit Entry</button>
         </form>
- 
+        <!-- <button type="submit" v-on:submit.prevent="isHidden == 'false'">Edit Entry</button>  -->
+    </div>
   </div>

      
    