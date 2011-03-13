startUpWithCaption: captionOrNil
	"Wait for the mouse button to go down.
	Display the menu, with caption if supplied.
	Track the selection as long as the button is pressed.
	When the button is released, answer the current selection."
	
	Cursor normal showWhile:
		[self displayAt: Sensor cursorPoint 
			withCaption: captionOrNil
			during: [Sensor cursorPoint: marker center.
					[Sensor anyButtonPressed] whileFalse: [].
					[Sensor anyButtonPressed] whileTrue: [self manageMarker]]].
	^selection