selectedDates
	| answer |
	answer _ SortedCollection new.
	self submorphsDo:
		[:each |
		(each isKindOf: WeekMorph) ifTrue: [answer addAll: each selectedDates]].
	^ answer 