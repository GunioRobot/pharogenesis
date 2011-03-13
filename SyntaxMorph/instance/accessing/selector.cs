selector
	"Find the SyntaxMorph that is a selectorNode within in me.  My parseNode is a MessageNode."

	^ submorphs detect: [:mm | 
			(mm isSyntaxMorph and: [mm nodeClassIs: SelectorNode])] 
		ifNone: [nil].