toss: cancelButton with: cancelSelector evt: evt
	"Reject the painting.  Showing noPalette is done by the block submitted to the SketchEditorMorph"

	| focus |
	owner ifNil: ["it happens"  ^ self].
	(focus _ self focusMorph) 
		ifNotNil: [focus cancelPainting: self evt: evt]
		ifNil:
			[self delete].
	cancelButton state: #off.
