inboardString
	^ inboard
		ifTrue:
			['switch to being outboard']
		ifFalse:
			['switch to being inboard']