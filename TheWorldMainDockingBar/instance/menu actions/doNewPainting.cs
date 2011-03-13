doNewPainting
	| w |
	w := self world.
	w
		assureNotPaintingElse: [^ self].
	w
		makeNewDrawing: (World primaryHand lastEvent copy setPosition: w center)