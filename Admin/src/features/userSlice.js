import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axiosClient from "../utils/axios";

const initialState = {
    users: [],
  };

  export const getAllUsersAsync = createAsyncThunk(
    "users/getAllUsers",
    async (values, { rejectWithValue }) => {
      try {
        const response = await axiosClient.get(`/user`);
        return response;
      } catch (error) {
        return rejectWithValue(error.response);
      }
    }
  );

  export const userSlice = createSlice({
    name: "user",
    initialState,
    extraReducers: (builder) => {
      builder
        .addCase(getAllUsersAsync.pending, (state, action) => {
            state.loading = true
        })
        .addCase(getAllUsersAsync.fulfilled, (state, action) => {
          console.log(action.payload);
          state.users = action.payload;
        })
        .addCase(getAllUsersAsync.rejected, (state, action) => {
          state.loading = false
      })
    },
  });
  
  export default userSlice.reducer;