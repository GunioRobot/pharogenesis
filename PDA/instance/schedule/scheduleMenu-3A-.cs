scheduleMenu: aMenu

	date ifNil: [^ aMenu add: 'select a date' target: self selector: #yourself.].
	self categorySelected ~= 'recurring' ifTrue:
		[aMenu add: 'add new event' target: self selector: #addEvent].
	aMenu add: 'add recurring event' target: self selector: #addRecurringEvent.
	scheduleListIndex > 0 ifTrue:
		[(currentItem isKindOf: PDARecurringEvent) ifTrue:
			[aMenu add: 'declare last date' target: self selector: #declareLastDate].
		aMenu add: 'remove event' target: self selector: #removeEvent].
	^ aMenu