isUnclassified: x
	^ categories noneSatisfy: [:c | c includes: x]
