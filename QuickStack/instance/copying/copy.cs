copy
	"Answer a copy of a myself"
	| newSize |
	newSize _ self basicSize.
	^ (self class new: newSize)
		replaceFrom: 1
		to: top
		with: self
		startingAt: 1;
		 setTop: top