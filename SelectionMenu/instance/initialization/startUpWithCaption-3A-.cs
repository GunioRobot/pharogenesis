startUpWithCaption: captionOrNil
	"Overridden to return inner values from manageMarker"
	| selectedItem |
	self displayAt: Sensor cursorPoint 
		withCaption: captionOrNil
		during: [Sensor cursorPoint: marker center.
				[Sensor anyButtonPressed] whileFalse: [].
				[Sensor anyButtonPressed]
					whileTrue: [selectedItem _ self manageMarker]].
	^ selectedItem