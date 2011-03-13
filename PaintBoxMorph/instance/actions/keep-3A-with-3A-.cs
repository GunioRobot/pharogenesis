keep: keepButton with: keepSelector
	"Showing of the corrent palette (viewer or noPalette) is done by the block submitted to the SketchMorphEditor, see (EToyHand makeNewDrawing) and (SketchMorph editDrawingInWorld:forBackground:)."
	| ss |
	owner ifNil: [^ self].
	keepButton ifNotNil: [keepButton state: #off].
	(ss _ self world findA: SketchEditorMorph) 
		ifNotNil: [ss save]
		ifNil:
		[keepSelector == #silent ifTrue: [^ self].
		self notCurrentlyPainting].