addCustomMenuItems: aCustomMenu hand: aHandMorph

	| movies |
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'repaint' action: #editDrawing.
	aCustomMenu add: 'set rotation center' action: #setRotationCenter.
	aCustomMenu add: 'set rotation style' action: #setRotationStyle.
	aCustomMenu add: 'erase pixels of color' action: #erasePixelsOfColor:.
	aCustomMenu add: 'recolor of pixels of color' action: #recolorPixelsOfColor:.
	movies _
		(self world rootMorphsAt: aHandMorph targetOffset)
			select: [:m | (m isKindOf: MovieMorph) or:
						[m isKindOf: SketchMorph]].
	(movies size > 1) ifTrue: [
		aCustomMenu add: 'insert into movie' action: #insertIntoMovie:].
