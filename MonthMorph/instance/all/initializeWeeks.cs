initializeWeeks
	| weeks |
	self removeAllMorphs.
	weeks _ OrderedCollection new.
	month eachWeekDo: [:each | weeks add: (WeekMorph newWeek: each month: month)].
	weeks reverseDo: [:each | self addMorph: each].
	self initializeHeader
