doNewPainting
	
	| w f |

	w _ self world.
	w assureNotPaintingElse: [^ self].
	(f _ self owner flapTab) ifNotNil: [f hideFlap].
	w makeNewDrawing: (self primaryHand lastEvent copy setPosition: w center)
