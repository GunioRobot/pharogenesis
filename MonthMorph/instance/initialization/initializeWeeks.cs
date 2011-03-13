initializeWeeks
	| weeks firstWeek lastWeek |
	self removeAllMorphs.
	weeks _ OrderedCollection new.
	(firstWeek _ month firstDate week) asDate dayOfMonth = 1 ifTrue:
		["If the entire first week is this month, then insert prior week"
		weeks add: (WeekMorph newWeek: firstWeek previous month: month tileRect: tileRect model: model)].
	month eachWeekDo:
		[:each |
		weeks add: (WeekMorph newWeek: (lastWeek _ each) month: month tileRect: tileRect model: model)].
	weeks size < 6 ifTrue:
		["If there's room at the bottom, add another week of next month."
		weeks add: (WeekMorph newWeek: lastWeek next month: month tileRect: tileRect model: model)].
	weeks reverseDo: [:each | 
		each hResizing: #spaceFill; vResizing: #spaceFill.
		"should be done by WeekMorph but isn't"
		each submorphsDo:[:m| m hResizing: #spaceFill; vResizing: #spaceFill].
		self addMorph: each].
	self initializeHeader.
	self highlightToday

