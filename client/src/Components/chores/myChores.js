import { useState } from "react";
import { completeChore, getMyChores } from "../../managers/choreManager";
import { Button, Table } from "reactstrap";

export const MyChores = ({ loggedInUser }) => {
 const [choreAssignments, setMyChores] = useState([]);
 async function getData() {
  getMyChores(loggedInUser).then(setMyChores);
 }
 useState(() => {
  getData();
 }, []);
 console.log(loggedInUser.id);
 if (choreAssignments === null) {
  return "";
 }

 return (
  <>
   <Table>
    <thead>
     <tr>
      <th>Chore</th>
      <th>Complete Chore</th>
     </tr>
    </thead>
    <tbody>
     {choreAssignments.map((c) => {
      // if logic here.
      if (c.chore.isOverdue == true) {
       return (
        <>
         <tr>
          <td>
           <p>{c.chore.name}</p>
          </td>
          <td>
           <Button
            color="primary"
            onClick={() => {
             completeChore(loggedInUser.id, c.id).then(() => {
              getData();
             });
            }}
           >
            Complete
           </Button>
          </td>
         </tr>
        </>
       );
      }
     })}
    </tbody>
   </Table>
  </>
 );
};
