tabSelected
	dragged == true ifTrue:
		[^ dragged _ false].
	self flapShowing
		ifTrue:
			[self hideFlap]
		ifFalse:
			[self showFlap]