toggleStartMonday

	self deprecated: 'Use #startDay:'.

	(self startDay = #Monday)
		ifTrue: [ self startDay: #Sunday ]
		ifFalse: [ self startDay: #Monday ]