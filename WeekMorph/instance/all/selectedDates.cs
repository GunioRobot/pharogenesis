selectedDates
	| answer |
	answer _ SortedCollection new.
	self submorphsDo:
		[:each |
		((each respondsTo: #onColor) and: [each color = each onColor])
			ifTrue:
				[answer add:
					(Date
						newDay: each label asNumber
						month: week firstDate monthName
						year: week firstDate year)]].
	^ answer