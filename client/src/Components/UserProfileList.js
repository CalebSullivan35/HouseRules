import { Button, Table } from "reactstrap";
import {
 getUserProfiles,
 getUserProfilesWithRoles,
} from "../managers/userProfileManager";
import { useEffect, useState } from "react";
import { Navigate, useNavigate } from "react-router-dom";

export const UserProfileList = () => {
 // Create a component called UserProfileList that shows all of the users in the system (you can decide what info about each user profile should be shown).
 const [userProfiles, setUserProfiles] = useState([]);
 const navigate = useNavigate();
 useEffect(() => {
  getUserProfilesWithRoles().then(setUserProfiles);
 }, []);

 //  const promote = (id) => {
 //   promoteUser(id).then(() => {
 //    getUserProfilesWithRoles().then(setUserProfiles);
 //   });
 //  };
 //  const demote = (id) => {
 //   demoteUser(id).then(() => {
 //    getUserProfilesWithRoles().then(setUserProfiles);
 //   });
 //  };

 return (
  <>
   <h2>User Profiles</h2>
   <Table>
    <thead>
     <tr>
      <th>Name</th>
      <th>Address</th>
      <th>Email</th>
      <th>Username</th>
      <th>Actions</th>
     </tr>
    </thead>
    <tbody>
     {userProfiles.map((up) => (
      <tr key={up.id}>
       <th scope="row">{`${up.firstName} ${up.lastName}`}</th>
       <td>{up.address}</td>
       <td>{up.email}</td>
       <td>{up.userName}</td>
       <td>
        {/* {up.roles.includes("Admin") ? (
         <Button
          color="danger"
          onClick={() => {
           demote(up.identityUserId);
          }}
         >
          Demote
         </Button>
        ) : (
         <Button
          color="success"
          onClick={() => {
           promote(up.identityUserId);
          }}
         >
          Promote
         </Button>
        )} */}
        <Button
         onClick={() => {
          navigate(`/userprofiles/${up.id}`);
         }}
        >
         Details
        </Button>
       </td>
      </tr>
     ))}
    </tbody>
   </Table>
  </>
 );

 // This component should only be viewable by admins.Create a separate route group called / userprofiles for this and the other UserProfile views.You will need to use the the roles prop on the AuthorizedRoute component to limit route access to admins.Add a link to the nav bar, conditionally rendered so that only admins will see the link(you will have to check if loggedInUser's roles includes "Admin"). Create a userProfileManager module to contain the functions to make fetch calls to the API.
};
