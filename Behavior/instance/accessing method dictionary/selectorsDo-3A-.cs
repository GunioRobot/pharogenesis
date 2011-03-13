selectorsDo: selectorBlock
	"Evaluate selectorBlock for all the message selectors in my method dictionary."

	^methodDict keysDo: selectorBlock