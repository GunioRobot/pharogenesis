normalizedWithin: bounds
	| center sp box scale |
	scale _ bounds extent y * 0.5.
	scale _ scale @ scale negated.
	box _ self boundingBox.
	center _ box origin + box corner * 0.5.
	sp _ POSimplePolygon new.
	vertices do: [:each|
		sp add: each - center / scale].
	^ sp