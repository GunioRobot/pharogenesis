initialize
	viewDescriptionOnly _ false.
	self userCategories: self sampleCategoryList
		allPeople: self samplePeopleList
		allEvents: self sampleScheduleList
		recurringEvents: self sampleRecurringEventsList
		allToDoItems: self sampleToDoList
		allNotes: self sampleNotes
		dateSelected: Date today
	