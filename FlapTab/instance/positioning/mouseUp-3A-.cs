mouseUp: evt
	super mouseUp: evt.
	self referentThickness <= 0 ifTrue: [flapShowing _ false].
	dragged _ false.
	self fitOnScreen.