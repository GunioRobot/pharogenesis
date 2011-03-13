openNearTarget

	| w wb tb leftOverlap rightOverlap topOverlap bottomOverlap best |

	w := myTarget world ifNil: [World].
	wb := w bounds.
	self fullBounds.
	tb := myTarget boundsInWorld.
	leftOverlap := self width - (tb left - wb left).
	rightOverlap := self width - (wb right - tb right).
	topOverlap := self height - (tb top - wb top).
	bottomOverlap := self height - (wb bottom - tb bottom).
	best := nil.
	{
		{leftOverlap. #topRight:. #topLeft}.
		{rightOverlap. #topLeft:. #topRight}.
		{topOverlap. #bottomLeft:. #topLeft}.
		{bottomOverlap. #topLeft:. #bottomLeft}.
	} do: [ :tuple |
		(best isNil or: [tuple first < best first]) ifTrue: [best := tuple].
	].
	self perform: best second with: (tb perform: best third).
	self bottom: (self bottom min: wb bottom) rounded.
	self right: (self right min: wb right) rounded.
	self top: (self top max: wb top) rounded.
	self left: (self left max: wb left) rounded.

	self openInWorld: w.