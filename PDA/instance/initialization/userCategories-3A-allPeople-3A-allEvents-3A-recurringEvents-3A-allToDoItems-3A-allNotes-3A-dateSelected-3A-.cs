userCategories: cats allPeople: ppl allEvents: evts recurringEvents: recEvts allToDoItems: todo allNotes: notes dateSelected: aDate

	userCategories _ cats.
	allPeople _ ppl.
	allEvents _ evts.
	recurringEvents _ recEvts.
	allToDoItems _ todo.
	allNotes _ notes.
	
	date _ aDate.  "Because updates ahead will need *both* date and category"
	self selectCategory: 'all'.
	self selectDate: aDate.  "Superfluous, but might not be"