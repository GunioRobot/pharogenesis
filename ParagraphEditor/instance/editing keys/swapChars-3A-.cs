swapChars: characterStream 
	"Triggered byCmd-Y;.  Swap two characters, either those straddling the insertion point, or the two that comprise the selection.  Suggested by Ted Kaehler.  "

	| currentSelection aString chars |
	sensor keyboard.		"flush the triggering cmd-key character"
	(chars _ self selection) size == 0
		ifTrue:
			[currentSelection _ self pointIndex.
			self selectMark: currentSelection - 1 point: currentSelection]
		ifFalse:
			[chars size == 2
				ifFalse:
					[view flash.  ^ true]
				ifTrue:
					[currentSelection _ self pointIndex - 1]].
	aString _ self selection string.
	self replaceSelectionWith: (Text string: aString reversed emphasis: emphasisHere).
	self selectAt: currentSelection + 1.
	^ true