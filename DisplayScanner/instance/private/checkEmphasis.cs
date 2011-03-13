checkEmphasis
	"convert mask to color 6/18/96 tk"
	| emphasis sourceRect y |
	(emphasis _ font emphasis) = 0 ifTrue: [^self].
	emphasis >= 8 ifTrue:  "struck out"
		[destForm
			fill: ((runX @ (lineY + textStyle baseline-3)) extent: (destX - runX) @ 1)
			rule: combinationRule fillColor: halftoneForm.	"color already converted to a Bitmap"
		emphasis _ emphasis - 8].
	emphasis >= 4 ifTrue:  "underlined"
		[destForm
			fill: ((runX @ (lineY + textStyle baseline)) extent: (destX - runX) @ 1)
			rule: combinationRule fillColor: halftoneForm.
		emphasis _ emphasis - 4].
	emphasis >= 2 ifTrue:  "itallic"
		[y _ lineY + textStyle lineGrid - 4.
		[y > lineY] whileTrue:
			[sourceRect _ runX @ lineY extent: (destX - runX - 1) @ (y - lineY).
			destForm
				copyBits: sourceRect from: destForm at: (runX+1) @ lineY
				clippingBox: sourceRect rule: Form over fillColor: nil.
			y _ y - 4].
		emphasis _ emphasis - 2].
	emphasis >= 1 ifTrue:  "bold face"
		[sourceRect _ runX @ lineY extent: (destX - runX - 1) @ textStyle lineGrid.
		destForm
			copyBits: sourceRect from: destForm at: (runX+1) @ lineY
			clippingBox: sourceRect rule: Form under fillColor: nil]