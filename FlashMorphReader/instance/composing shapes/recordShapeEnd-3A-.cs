recordShapeEnd: shapeId
	| shape |
	self endShape.
	shape _ FlashCharacterMorph withAll: (currentShape contents reversed).
	shape lockChildren.
	currentShape resetToStart.
	shape id: shapeId.
	shape stepTime: stepTime.
	shapes at: shapeId put: shape.
	self doLog ifTrue:[log _ Transcript].