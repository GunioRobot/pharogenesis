selectorsAndMethodsDo: aBlock
	"Evaluate selectorBlock for all the message selectors in my method dictionary."

	^ self methodDict keysAndValuesDo: aBlock