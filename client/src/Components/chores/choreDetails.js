import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getChoreDetails } from "../../managers/choreManager";
import { ListGroup, ListGroupItem, Table } from "reactstrap";

export const ChoreDetails = () => {
 const { id } = useParams();
 const [chore, setChore] = useState();
 useEffect(() => {
  getChoreDetails(parseInt(id)).then(setChore);
 }, []);

 if (chore == null) {
  return "";
 }

 return (
  <>
   <h1>Chore Details</h1>
   <ListGroup>
    <ListGroupItem>Name: {chore.name} </ListGroupItem>
    <ListGroupItem>Difficulty: {chore.difficulty}</ListGroupItem>
    <ListGroupItem>
     Chore Frequency: {chore.choreFrequencyDays} Days
    </ListGroupItem>
    <ListGroupItem>
     Most Recent Completion Day :{" "}
     {chore.choreCompletions.length > 0
      ? chore.choreCompletions[
         chore.choreCompletions.length - 1
        ].completedOn.split("T")[0]
      : ""}
    </ListGroupItem>
   </ListGroup>
   <Table>
    <thead>
     <tr>
      <th>Current Assignees</th>
     </tr>
    </thead>
    <tbody>
     {chore.choreAssignments.map((ca) => {
      return (
       <td>
        {" "}
        Name: {ca.userProfile.firstName} {ca.userProfile.lastName}
       </td>
      );
     })}
    </tbody>
   </Table>
  </>
 );
};
