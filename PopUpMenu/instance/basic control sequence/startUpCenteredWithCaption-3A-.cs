startUpCenteredWithCaption: captionOrNil
	"Differs from startUpWithCaption: by appearing with cursor in the menu,
	and thus ready to act on mouseUp, without requiring user tweak to confirm"

	^ self startUpWithCaption: captionOrNil at: Sensor cursorPoint - (frame width//2@0)