import { configureStore } from '@reduxjs/toolkit'
import CategoryReducer from '../features/categorySlice';

import { getDefaultMiddleware } from '@reduxjs/toolkit';
import createOidcMiddleware from "redux-oidc";
// import userManager from "../utils/userManager";
import { reducer as oidc } from "redux-oidc";


export const store = configureStore({
  reducer: {
    category: CategoryReducer,

    oidc: oidc
  },
  middleware: [...getDefaultMiddleware({
    serializableCheck: false
  })/* , (createOidcMiddleware(userManager)) */]
})