crWithIndent: characterStream 
	"Replace the current text selection with CR followed by as many tabs
	as on the current line (+/- bracket count) -- initiated by Shift-Return."
	| char s i tabCount |
	sensor keyboard.		"flush character"
	s _ paragraph string.
	i _ self stopIndex.
	tabCount _ 0.
	[(i _ i-1) > 0 and: [(char _ s at: i) ~= Character cr]]
		whileTrue:  "Count tabs and brackets (but not a leading bracket)"
		[(char = Character tab and: [i < s size and: [(s at: i+1) ~= $[ ]]) ifTrue: [tabCount _ tabCount + 1].
		char = $[ ifTrue: [tabCount _ tabCount + 1].
		char = $] ifTrue: [tabCount _ tabCount - 1]].
	characterStream crtab: tabCount.  "Now inject CR with tabCount tabs"
	^ false