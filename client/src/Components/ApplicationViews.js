import { Route, Routes } from "react-router-dom";

import { AuthorizedRoute } from "./auth/AuthorizedRoute";

import Register from "./auth/Register";
import Login from "./auth/Login";
import { Home } from "./home/home";
import { UserProfileList } from "./UserProfileList";
import { UserProfileDetails } from "./UserProfileDetails";
import { ChoresList } from "./chores/ChoresList";
import { ChoreDetails } from "./chores/choreDetails";
import { CreateChore } from "./chores/createChore";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
 return (
  <Routes>
   <Route path="/">
    <Route
     index
     element={
      <AuthorizedRoute loggedInUser={loggedInUser}>
       <Home />
      </AuthorizedRoute>
     }
    />
    <Route
     path="/chores"
     index
     element={
      <AuthorizedRoute loggedInUser={loggedInUser}>
       <ChoresList loggedInUser={loggedInUser} />
      </AuthorizedRoute>
     }
    />
    <Route
     path="chores/:id"
     element={
      <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
       <ChoreDetails />
      </AuthorizedRoute>
     }
    />
    <Route
     path="addChore"
     element={
      <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
       <CreateChore />
      </AuthorizedRoute>
     }
    />
    <Route
     path="userprofiles"
     element={
      <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
       <UserProfileList />
      </AuthorizedRoute>
     }
    />
    <Route
     path="userprofiles/:id"
     element={
      <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
       <UserProfileDetails />
      </AuthorizedRoute>
     }
    />
    <Route path="login" element={<Login setLoggedInUser={setLoggedInUser} />} />
    <Route
     path="register"
     element={<Register setLoggedInUser={setLoggedInUser} />}
    />
   </Route>
   <Route path="*" element={<p>Whoops, nothing here...</p>} />
  </Routes>
 );
}
