keyStroke: anEvent
	"Handle a keystroke event in the panel; we map f (for find) into a switch to the ? category"

	(anEvent keyCharacter == $f) ifTrue:
		[^ self switchToCategoryNamed: #? event: nil]