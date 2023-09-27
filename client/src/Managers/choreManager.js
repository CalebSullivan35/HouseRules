const _apiUrl = "/api/chore";

export const getChores = () => {
 return fetch(_apiUrl).then((res) => res.json());
};

export const deleteChore = (id) => {
 return fetch(`${_apiUrl}/${id}`, {
  method: "DELETE",
 });
};

export const getChoreDetails = (id) => {
 return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const createChore = (chore) => {
 return fetch(_apiUrl, {
  method: "POST",
  headers: {
   "Content-Type": "application/json",
  },
  body: JSON.stringify(chore),
 }).then((res) => res.json());
};

export const completeChore = (userId, choreId) => {
 return fetch(`${_apiUrl}/${userId}/complete?choreId=${choreId}`, {
  method: "POST",
 });
};

export const assignChore = (userId, choreId) => {
 return fetch(`${_apiUrl}/${userId}/assign?choreId=${choreId}`, {
  method: "POST",
 });
};

export const unassignChore = (userId, choreId) => {
 return fetch(`${_apiUrl}/${userId}/unassign?choreId=${choreId}`, {
  method: "POST",
 });
};

export const updateChore = (chore, choreId) => {
 return fetch(`${_apiUrl}/${choreId}`, {
  method: "PUT",
  headers: {
   "Content-Type": "application/json",
  },
  body: JSON.stringify(chore),
 });
};

export const getMyChores = (user) => {
 return fetch(`${_apiUrl}/mychores/${user.id}`).then((res) => res.json());
};
