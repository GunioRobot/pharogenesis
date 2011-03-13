showHiders
	| container |
	container _ argument ifNotNil: [argument] ifNil: [self world].
	container allMorphsDo:
		[:m | m show]