import { useEffect, useState } from "react";
import {
 completeChore,
 deleteChore,
 getChores,
} from "../../managers/choreManager";
import { Button, Table } from "reactstrap";
import { useNavigate } from "react-router-dom";

export const ChoresList = ({ loggedInUser }) => {
 const [choresList, setChoresList] = useState([]);
 function getdata() {
  getChores().then(setChoresList);
 }
 const navigate = useNavigate();
 useEffect(() => {
  getdata();
 }, []);

 function handleDeleteButton(id) {
  deleteChore(id).then(getdata());
 }

 //handle if chore is or is not
 const checkChore = (chore) => {
  const className = chore.isOverdue ? "redtext" : "";
  return <p className={className}>{chore.name}</p>;
 };

 return (
  <>
   <Button
    color="primary"
    onClick={() => {
     navigate("/addChore");
    }}
   >
    Add Chore
   </Button>
   <Table>
    <thead>
     <tr>
      <th>Name</th>
      <th>Frequency</th>
      <th>Difficulty Rating</th>
      <th>Actions</th>
     </tr>
    </thead>
    <tbody>
     {choresList.map((c) => (
      <tr key={c.id}>
       <td>{checkChore(c)}</td>
       <td>{c.choreFrequencyDays} Days</td>
       <td>{c.difficulty}</td>
       <td>
        <Button
         color="primary"
         onClick={() => {
          completeChore(loggedInUser.id, c.id).then(() => {
           getdata();
          });
         }}
        >
         Complete
        </Button>

        {loggedInUser.roles.includes("Admin") ? (
         <>
          <Button
           color="info"
           onClick={() => {
            navigate(`/chores/${c.id}`);
           }}
          >
           Details
          </Button>
          <Button
           color="danger"
           onClick={() => {
            handleDeleteButton(c.id);
            console.log(c.id);
           }}
          >
           Delete
          </Button>
         </>
        ) : (
         ""
        )}
       </td>
      </tr>
     ))}
    </tbody>
   </Table>
  </>
 );
};
