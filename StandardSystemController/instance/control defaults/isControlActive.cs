isControlActive
	status == #active ifFalse: [^ false].
	sensor anyButtonPressed ifFalse: [^ true].
	self viewHasCursor
		ifTrue: [^ true]
		ifFalse: [ScheduledControllers noteNewTop.
				^ false]