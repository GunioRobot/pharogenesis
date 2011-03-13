doNewPainting
	
	| w |

	w _ self world.
	w assureNotPaintingElse: [^ self].
	w makeNewDrawing: (self primaryHand lastEvent copy setPosition: w center)