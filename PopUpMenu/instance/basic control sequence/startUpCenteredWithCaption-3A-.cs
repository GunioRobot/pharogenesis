startUpCenteredWithCaption: captionOrNil
	"Differs from startUpWithCaption: by appearing with cursor in the menu,
	and thus ready to act on mouseUp, without requiring user tweak to confirm"

	| cursorPoint |
	cursorPoint _ Smalltalk isMorphic 
			ifTrue: [World cursorPoint]
			ifFalse: [Sensor cursorPoint].
	^ self startUpWithCaption: captionOrNil at: cursorPoint - (20@0)