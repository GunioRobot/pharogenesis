setupBorder

	self patchesDo: [:p |
		p isLeftEdge | p isRightEdge |
		p isTopEdge | p isBottomEdge ifTrue: [
			p set: #isUnburnt to: 0.
			p color: Color blue]].
