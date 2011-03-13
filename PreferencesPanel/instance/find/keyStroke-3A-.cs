keyStroke: anEvent
	"Handle a keystroke event in the panel; we map f into a #findPreference: call here"

	(anEvent keyCharacter == $f) ifTrue:
		[^ self findPreference: anEvent]