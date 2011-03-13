grow
	| newStack |
	newStack := self class new: (self basicSize * 2).
	newStack replaceFrom: 1 to: top with: self startingAt: 1.
	newStack setTop: top.
	self becomeForward: newStack.
