recordLineSegmentBy: deltaPoint
	| target |
	target _ location + deltaPoint.
	self addLineFrom: location to: target via: location.
	location _ target.