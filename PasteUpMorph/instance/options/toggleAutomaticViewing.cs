toggleAutomaticViewing
	| current |
	current _ self automaticViewing.
	current
		ifTrue:
			[self removeProperty: #automaticViewing]
		ifFalse:
			[self setProperty: #automaticViewing toValue: true]