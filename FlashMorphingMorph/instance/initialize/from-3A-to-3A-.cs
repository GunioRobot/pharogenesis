from: srcMorph to: dstMorph
	| shape |
	"Note: Add srcMorph and dstMorph to the receiver so the damned bounds will be correct."
	self addMorphBack: srcMorph.
	self addMorphBack: dstMorph.
	self computeBounds.
	srcShapes := self extractShapesFrom: srcMorph.
	dstShapes := self extractShapesFrom: dstMorph.
	srcShapes size = dstShapes size ifFalse:[^self error:'Shape size mismatch'].
	1 to: srcShapes size do:[:i|
		(srcShapes at: i) numSegments = (dstShapes at: i) numSegments
			ifFalse:[^self error:'Edge size mismatch']].
	morphShapes := WriteStream on: Array new.
	srcShapes do:[:s|
		shape := FlashBoundaryShape
					points: s points copy
					leftFills: s leftFills
					rightFills: s rightFills
					fillStyles: s fillStyles
					lineWidths: s lineWidths
					lineFills: s lineFills.
		morphShapes nextPut: shape.
		self addMorphFront: (FlashShapeMorph shape: shape)].
	morphShapes := morphShapes contents.
	srcMorph visible: false.
	dstMorph visible: false.