startUpCenteredWithCaption: captionOrNil
	"Differs from startUpWithCaption: by appearing with cursor in the menu,
	and thus ready to act on mouseUp, without requiring user tweak to confirm"
	
	Cursor normal showWhile:
		[self displayAt: Sensor cursorPoint - (frame width//2@0)
			withCaption: captionOrNil
			during: [[Sensor anyButtonPressed] whileFalse: [].
					[Sensor anyButtonPressed] whileTrue: [self manageMarker]]].
	^selection