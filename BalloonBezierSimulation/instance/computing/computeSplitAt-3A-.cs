computeSplitAt: t
	"Split the receiver at the parametric value t"
	| left right newVia1 newVia2 newPoint |
	left _ self clone.
	right _ self clone.
	"Compute new intermediate points"
	newVia1 _ (via - start) * t + start.
	newVia2 _ (end - via) * t + via.
	"Compute new point on curve"
	newPoint _ ((newVia1 - newVia2) * t + newVia2) asIntegerPoint.
	left via: newVia1 asIntegerPoint.
	left end: newPoint.
	right start: newPoint.
	right via: newVia2 asIntegerPoint.
	^Array with: left with: right