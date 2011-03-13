recordLineSegmentBy: deltaPoint
	| target |
	target := location + deltaPoint.
	self addLineFrom: location to: target via: location.
	location := target.