extent: newExtent
	| scaleFactor |
	self adjustAfter:
		[scaleFactor _ (self scale * newExtent r / self fullBounds extent r) max: 0.1.
		self scale: (scaleFactor detentBy: 0.1 atMultiplesOf: 1.0 snap: false)]