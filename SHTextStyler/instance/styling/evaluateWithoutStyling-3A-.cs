evaluateWithoutStyling: aBlock
	|t|
	t := stylingEnabled.
	[stylingEnabled := false.
	aBlock value]
		ensure: [stylingEnabled := t]