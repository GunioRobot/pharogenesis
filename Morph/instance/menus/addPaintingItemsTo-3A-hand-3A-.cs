addPaintingItemsTo: aMenu hand: aHandMorph 
	| subMenu movies |
	subMenu := MenuMorph new defaultTarget: self.
	subMenu add: 'repaint' translated action: #editDrawing.
	subMenu add: 'set rotation center' translated action: #setRotationCenter.
	subMenu add: 'reset forward-direction' translated
		action: #resetForwardDirection.
	subMenu add: 'set rotation style' translated action: #setRotationStyle.
	subMenu add: 'erase pixels of color' translated
		action: #erasePixelsOfColor:.
	subMenu add: 'recolor pixels of color' translated
		action: #recolorPixelsOfColor:.
	subMenu add: 'reduce color palette' translated action: #reduceColorPalette:.
	subMenu add: 'add a border around this shape...' translated
		action: #addBorderToShape:.
	movies := (self world rootMorphsAt: aHandMorph targetOffset) 
				select: [:m | (m isKindOf: MovieMorph) or: [m isSketchMorph]].
	movies size > 1 
		ifTrue: 
			[subMenu add: 'insert into movie' translated action: #insertIntoMovie:].
	aMenu add: 'painting...' translated subMenu: subMenu