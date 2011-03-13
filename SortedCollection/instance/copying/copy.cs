copy

	| newCollection |
	newCollection := self species sortBlock: sortBlock.
	newCollection addAll: self.
	^newCollection