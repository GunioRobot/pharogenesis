recordMorphShapeStart: shapeId srcBounds: bounds1 dstBounds: bounds2
	morphedFillStyles _ Dictionary new.
	morphedLineStyles _ Dictionary new.
	location _ 0@0.
	self logShapes ifFalse:[log _ nil].
	self beginShape.