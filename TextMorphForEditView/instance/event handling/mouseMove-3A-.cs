mouseMove: evt
	| editEvt |
	super mouseMove: evt.
	editEvt _ evt transformedBy: (self transformedFrom: editView) inverseTransformation.
	(editEvt position y between: editView top and: editView bottom) ifFalse:[
		"Start auto-scrolling"
		self startStepping: #autoScrollView:
			at: Time millisecondClockValue
			arguments: (Array with: editEvt)
			stepTime: 100. "fast enough"
	] ifTrue:[
		self stopSteppingSelector: #autoScrollView:.
	].