removeAt: index
	| removed |
	removed _ self at: index.
	self removeIndex: index + firstIndex - 1.
	^removed