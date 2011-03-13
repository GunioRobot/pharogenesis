addPaintingItemsTo: aMenu hand: aHandMorph
	| subMenu movies |
	subMenu _ MenuMorph new defaultTarget: self.

	subMenu add: 'repaint' action: #editDrawing.
	subMenu add: 'set rotation center' action: #setRotationCenter.
	subMenu add: 'set rotation style' action: #setRotationStyle.
	subMenu add: 'erase pixels of color' action: #erasePixelsOfColor:.
	subMenu add: 'recolor of pixels of color' action: #recolorPixelsOfColor:.
	movies _
		(self world rootMorphsAt: aHandMorph targetOffset)
			select: [:m | (m isKindOf: MovieMorph) or:
						[m isKindOf: SketchMorph]].
	(movies size > 1) ifTrue:
		[subMenu add: 'insert into movie' action: #insertIntoMovie:].
	aMenu add: 'painting...' subMenu: subMenu