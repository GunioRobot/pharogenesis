toss: cancelButton with: cancelSelector
	"Reject the painting.  Showing noPalette is done by the block submitted to the SketchMorphEditor, see (EToyHand makeNewDrawing) and (SketchMorph editDrawingInWorld:forBackground:)."

	| ss |
	owner ifNil: ["it happens"  ^ self].
	(ss _ self world findA: SketchEditorMorph) 
		ifNotNil: [ss cancel]
		ifNil: [PopUpMenu notify: 
			'You are currently not painting.  Choose 
Parts and drag out a new object.'
			"Later have to change this for no EToy"].
	cancelButton state: #off.
