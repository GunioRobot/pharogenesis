startUpCenteredWithCaption: captionOrNil
	"Differs from startUpWithCaption: by appearing with cursor in the menu,
	and thus ready to act on mouseUp, without requiring user tweak to confirm"

	| cursorPoint |
	cursorPoint _ Display lastKnownCursorPoint.
	^ self startUpWithCaption: captionOrNil at: cursorPoint - (20@0)