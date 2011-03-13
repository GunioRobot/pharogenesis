isObscured

	| topController displayRect |
	(topController := self topView controller)
		== ScheduledControllers activeController
			ifTrue: [^false].
	displayRect := self insetDisplayBox.
	ScheduledControllers scheduledControllers do: [:ctrlr |
		ctrlr == topController ifTrue: [^false].
		(displayRect intersects: ctrlr view insetDisplayBox)
			ifTrue: [^true]].
	self error: 'not in ScheduledControllers'.
	^false