startUpWithCaption: captionOrNil
	"Display the menu, slightly offset from the cursor,
	so that a slight tweak is required to confirm any action."

	^ self startUpWithCaption: captionOrNil
		at: (Smalltalk isMorphic 
			ifTrue: [World cursorPoint]
			ifFalse: [Sensor cursorPoint])