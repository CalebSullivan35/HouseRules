import { useState } from "react";
import { Button, Input, InputGroup, InputGroupText } from "reactstrap";
import { createChore } from "../../managers/choreManager";
import { useNavigate } from "react-router-dom";

export const CreateChore = () => {
 const [newDifficulty, setDifficulty] = useState(1);
 const [newFrequency, setFrequency] = useState(1);
 const [choreName, setChoreName] = useState("");
 const [errors, setErrors] = useState([]);
 const navigate = useNavigate();
 const handleDifficultyChange = (e) => {
  setDifficulty(e.target.value);
 };

 const handleFrequencyChange = (e) => {
  setFrequency(e.target.value);
 };

 const handleCreateChore = (evt) => {
  evt.preventDefault();
  const newChore = {
   name: choreName,
   difficulty: newDifficulty,
   choreFrequencyDays: newFrequency,
  };
  createChore(newChore).then((res) => {
   if (res.errors) {
    setErrors(res.errors);
   } else {
    navigate("/chores");
   }
  });
 };

 return (
  <>
   <h1>Create Chore Page</h1>
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
      handleCreateChore(e);
     }}
    >
     Submit New Product
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
