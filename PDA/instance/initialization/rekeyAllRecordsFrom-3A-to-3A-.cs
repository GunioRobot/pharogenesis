rekeyAllRecordsFrom: oldKey to: newKey

	allPeople do: [:r | r rekey: oldKey to: newKey].
	allEvents do: [:r | r rekey: oldKey to: newKey].
	recurringEvents do: [:r | r rekey: oldKey to: newKey].
	allToDoItems do: [:r | r rekey: oldKey to: newKey].
	allNotes do: [:r | r rekey: oldKey to: newKey].
