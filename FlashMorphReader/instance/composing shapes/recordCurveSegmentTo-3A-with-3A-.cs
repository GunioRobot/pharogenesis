recordCurveSegmentTo: anchorPoint with: controlPoint
	| target midPoint |
	midPoint _ location + controlPoint.
	target _ midPoint + anchorPoint.
	self addLineFrom: location to: target via: midPoint.
	location _ target.