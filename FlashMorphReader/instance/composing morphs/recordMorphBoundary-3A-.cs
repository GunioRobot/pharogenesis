recordMorphBoundary: id
	self recordShapeEnd: id.
	morphedLineStyles keysAndValuesDo:[:idx :val| lineStyles at: idx put: val].
	morphedFillStyles keysAndValuesDo:[:idx :val| fillStyles at: idx put: val].
	location _ 0@0.
	self beginShape.