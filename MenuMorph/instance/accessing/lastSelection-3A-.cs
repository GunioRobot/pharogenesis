lastSelection: aString
	"Set the last selection so that it is selected by default when this menu first pops up."

	lastSelection _ self items
		detect: [:each | each selector == aString] ifNone: [nil].
