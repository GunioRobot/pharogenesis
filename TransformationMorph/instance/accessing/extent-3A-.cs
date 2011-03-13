extent: newExtent
	| r0 |
	self adjustAfter:
		[r0 _ self firstSubmorph extent r.
		self scale: ((newExtent r / r0 max: 0.1)
				 detentBy: 0.1 atMultiplesOf: 1.0 snap: false)]