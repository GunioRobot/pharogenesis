computeFullBounds: cameraMorph
	self submorphsDo:[:m| m computeFullBounds: cameraMorph].
	self computeBounds: cameraMorph.
	fullBounds _ nil.