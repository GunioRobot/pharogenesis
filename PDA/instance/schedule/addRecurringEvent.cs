addRecurringEvent
	| newEvent |
	newEvent _ PDARecurringEvent new key: self categorySelected;
						firstDate: date; recurrence: PDARecurringEvent chooseRecurrence;
						description: 'recurring event'.
	newEvent key = 'recurring' ifTrue: [newEvent key: 'all'].
	newEvent recurrence == #eachDay ifTrue: [newEvent lastDate: (date addDays: 1)].
	recurringEvents _ recurringEvents copyWith: newEvent.
	self currentItem: newEvent.
	self updateScheduleList