addEvent
	| newEvent |
	newEvent _ PDAEvent new key: self categorySelected; date: date;
						time: (Time readFromString: '7 am');
						description: 'new event'.
	allEvents _ allEvents copyWith: newEvent.
	self currentItem: newEvent.
	self updateScheduleList