containsPoint: aPoint event: anEvent
	(anEvent isMouseOver or:[firstPersonControls == true]) ifTrue:[
		"Approximate for mouseOver; they're just sent too often"
		^self bounds containsPoint: aPoint].
	^super containsPoint: aPoint event: anEvent