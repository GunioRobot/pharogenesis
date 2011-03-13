swapChars: characterStream 
	"Triggered byCmd-Y;.  Swap two characters, either those straddling the insertion point, or the two that comprise the selection.  Suggested by Ted Kaehler.  1/18/96 sw"

	| currentSelection aString chars |
	sensor keyboard.		"flush the triggering cmd-key character"
	(chars _ self selection) size == 0
		ifTrue:
			[currentSelection _ startBlock stringIndex]
		ifFalse:
			[chars size == 2
				ifFalse:
					[view flash.  ^ true]
				ifTrue:
					[currentSelection _ startBlock stringIndex + 1]].

	self selectFrom: currentSelection - 1 to: currentSelection.
	aString _ self selection string.
	self replaceSelectionWith: (Text fromString: aString backwards).
	self selectAt: currentSelection + 1.
	^ true