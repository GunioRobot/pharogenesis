mouseDown: evt

	self displayCostume: #mouseDown.
	mouseDownTime _ Time millisecondClockValue.
	nextTimeToFire _ nil.
	delayBetweenFirings ifNotNil: [
		nextTimeToFire _ mouseDownTime + delayBetweenFirings.
	].
	self wantsRolloverIndicator ifTrue: [
		visibleMorph 
			addMouseActionIndicatorsWidth: mouseDownHaloWidth 
			color: mouseDownHaloColor.
	].
	actWhen == #mouseDown ifFalse: [^self].
	(visibleMorph containsPoint: evt cursorPoint) ifFalse: [^self].
	self doButtonAction: evt.

"=====

	aMorph .

	now _ Time millisecondClockValue.
	oldColor _ color. 
	actWhen == #buttonDown
		ifTrue: [self doButtonAction]
		ifFalse: [	self updateVisualState: evt; refreshWorld].
	dt _ Time millisecondClockValue - now max: 0.
	dt < 200 ifTrue: [(Delay forMilliseconds: 200-dt) wait].
	self mouseStillDown: evt.
====="