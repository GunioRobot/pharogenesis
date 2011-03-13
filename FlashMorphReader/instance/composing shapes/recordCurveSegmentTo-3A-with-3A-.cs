recordCurveSegmentTo: anchorPoint with: controlPoint
	| target midPoint |
	midPoint := location + controlPoint.
	target := midPoint + anchorPoint.
	self addLineFrom: location to: target via: midPoint.
	location := target.