openNearTarget

	| w wb tb leftOverlap rightOverlap topOverlap bottomOverlap best |

	w _ myTarget world ifNil: [World].
	wb _ w bounds.
	self fullBounds.
	tb _ myTarget boundsInWorld.
	leftOverlap _ self width - (tb left - wb left).
	rightOverlap _ self width - (wb right - tb right).
	topOverlap _ self height - (tb top - wb top).
	bottomOverlap _ self height - (wb bottom - tb bottom).
	best _ nil.
	{
		{leftOverlap. #topRight:. #topLeft}.
		{rightOverlap. #topLeft:. #topRight}.
		{topOverlap. #bottomLeft:. #topLeft}.
		{bottomOverlap. #topLeft:. #bottomLeft}.
	} do: [ :tuple |
		(best isNil or: [tuple first < best first]) ifTrue: [best _ tuple].
	].
	self perform: best second with: (tb perform: best third).
	self bottom: (self bottom min: wb bottom) rounded.
	self right: (self right min: wb right) rounded.
	self top: (self top max: wb top) rounded.
	self left: (self left max: wb left) rounded.

	self openInWorld: w.