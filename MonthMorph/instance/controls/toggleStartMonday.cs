toggleStartMonday

	(Week startDay = #Monday)
		ifTrue: [ Week startDay: #Sunday ]
		ifFalse: [ Week startDay: #Monday ].

	self initializeWeeks
