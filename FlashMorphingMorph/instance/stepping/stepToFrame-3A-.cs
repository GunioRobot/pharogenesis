stepToFrame: frameNumber
	| ratio |
	super stepToFrame: frameNumber.
	self visible ifTrue:[
		ratio := self ratioAtFrame: frame.
		self morphTo: ratio.
		self changed].