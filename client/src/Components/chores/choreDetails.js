import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
 assignChore,
 createChore,
 getChoreDetails,
 unassignChore,
 updateChore,
} from "../../managers/choreManager";
import {
 InputGroup,
 Label,
 ListGroup,
 ListGroupItem,
 Table,
 Input,
 InputGroupText,
 Button,
} from "reactstrap";
import { getUserProfiles } from "../../managers/userProfileManager";

export const ChoreDetails = () => {
 const { id } = useParams();
 const [chore, setChore] = useState();
 const [users, setUsers] = useState([]);
 const [newDifficulty, setDifficulty] = useState(1);
 const [newFrequency, setFrequency] = useState(1);
 const [choreName, setChoreName] = useState("");
 const [errors, setErrors] = useState([]);
 const navigate = useNavigate();
 async function getData() {
  getUserProfiles().then(setUsers);
  getChoreDetails(parseInt(id)).then(setChore);
 }

 useEffect(() => {
  getData();
 }, []);

 const handleUserCheckbox = (e, user) => {
  const { checked } = e.target;
  const promise = checked
   ? assignChore(user.id, chore.id)
   : unassignChore(user.id, chore.id);

  promise.then(() => getData());
  console.log(user);
 };
 const handleDifficultyChange = (e) => {
  setDifficulty(e.target.value);
 };

 const handleFrequencyChange = (e) => {
  setFrequency(e.target.value);
 };
 const handleUpdateChore = (evt) => {
  evt.preventDefault();
  const newChore = {
   name: choreName,
   difficulty: newDifficulty,
   choreFrequencyDays: newFrequency,
  };
  updateChore(newChore, chore.id).then((res) => {
   if (res.errors) {
    setErrors(res.errors);
   } else {
    navigate("/chores");
   }
  });
 };

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

   <h2>Assigned To</h2>

   {users.map((user) => {
    return (
     <div>
      <label htmlFor="users">
       {users.firstName} {users.lastName}
      </label>
      <input
       type="checkbox"
       name="users"
       checked={
        !!chore?.choreAssignments?.find((c) => c.userProfileId === user.id)
       }
       onChange={(e) => handleUserCheckbox(e, user)}
      />
      Name: {user.firstName} {user.lastName}
     </div>
    );
   })}

   <h1>Update Chore </h1>
   <div className="formContainer">
    <div className="choreNameInput">
     <InputGroup>
      <InputGroupText>Chore Name:</InputGroupText>
      <Input onChange={(e) => setChoreName(e.target.value)} />
     </InputGroup>
    </div>
    <div className="dropDownGroup">
     <h4>Difficulty</h4>
     <select onChange={handleDifficultyChange} value={newDifficulty}>
      <option value="" disabled>
       Difficulty
      </option>
      <option value={1}>1</option>
      <option value={2}>2</option>
      <option value={3}>3</option>
      <option value={4}>4</option>
      <option value={5}>5</option>
     </select>
     <h4>Frequency</h4>
     <select
      onChange={handleFrequencyChange}
      value={newFrequency}
      className="selector"
     >
      <option value="" disabled>
       Frequency
      </option>
      <option value={1}>Daily</option>
      <option value={2}>Two Days</option>
      <option value={7}>Weekly</option>
      <option value={14}>BiWeekly</option>
      <option value={30}>Monthly</option>
     </select>
    </div>
    <Button
     onClick={(e) => {
      handleUpdateChore(e);
     }}
    >
     Submit Changes
    </Button>
   </div>
   <div style={{ color: "red" }}>
    {Object.keys(errors).map((key) => (
     <p key={key}>
      {key}: {errors[key].join(",")}
     </p>
    ))}
   </div>
  </>
 );
};
