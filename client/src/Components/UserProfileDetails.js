import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getUserProfileDetails } from "../managers/userProfileManager";
import { ListGroup, ListGroupItem, Table } from "reactstrap";

export const UserProfileDetails = () => {
 const [user, setUser] = useState({});
 const { id } = useParams();
 console.log(typeof parseInt(id));
 useEffect(() => {
  getUserProfileDetails(parseInt(id)).then(setUser);
 }, []);

 return (
  <>
   <h1>User Profile Details</h1>
   <ListGroup>
    <ListGroupItem>Name: {user.firstName}</ListGroupItem>
    <ListGroupItem>Email: {user.identityUser?.email}</ListGroupItem>
    <ListGroupItem>Address: {user.address}</ListGroupItem>
   </ListGroup>
   <Table>
    <thead>
     <tr>
      <th>Chore</th>
      <th>Completed On</th>
     </tr>
    </thead>
    <tbody>
     {user.choreAssignments?.map((c) => (
      <tr key={c.id}>
       <td>{c.chore.name}</td>
       <td>{c.chore.choreCompletions[0].completedOn.split("T")[0]}</td>
      </tr>
     ))}
    </tbody>
   </Table>
  </>
 );
};
// Create a component called UserProfileDetails that allows an admin to view a user's profile details (all of the properties in UserProfile except the Id), their currently assigned chore names as well as the chores that they have completed (including the completion date).

// Add a "Details" link to each of the user profiles in the list component that navigates to the details view for a user profile.Make sure that the route is protected with the AuthorizedRoute component, specifying the "Admin" role, so that if a non - admin user navigates there directly from the browser, they will be redirected to the login page.
