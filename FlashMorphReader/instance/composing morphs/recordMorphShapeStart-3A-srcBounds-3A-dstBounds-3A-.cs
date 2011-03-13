recordMorphShapeStart: shapeId srcBounds: bounds1 dstBounds: bounds2
	morphedFillStyles := Dictionary new.
	morphedLineStyles := Dictionary new.
	location := 0@0.
	self logShapes ifFalse:[log := nil].
	self beginShape.