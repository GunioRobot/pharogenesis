toss: cancelButton with: cancelSelector
	"Reject the painting.  Showing noPalette is done by the block submitted to the SketchEditorMorph"

	| focus |
	owner ifNil: ["it happens"  ^ self].
	(focus _ self focusMorph) 
		ifNotNil: [focus cancelPainting: self]
		ifNil:
			[self delete].
	cancelButton state: #off.
