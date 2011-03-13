month: aMonth
	month _ aMonth.
	model ifNotNil: [model setDate: nil fromButton: nil down: false].
	self initializeWeeks