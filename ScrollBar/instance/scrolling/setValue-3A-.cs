setValue: newValue
	^ super setValue: (newValue + 0.0001 truncateTo: scrollDelta)