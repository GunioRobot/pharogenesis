sizeForStorePop: encoder
	"N, toBraceStack:, pop, pop elemN, ..., pop elem1"

	nElementsNode _ encoder encodeLiteral: elements size.
	toBraceStackNode _ encoder encodeSelector: #toBraceStack:.
	^elements inject:
		(nElementsNode sizeForValue: encoder) +
		(toBraceStackNode size: encoder args: 1 super: false) + 1 into:
			[:subTotal :element |
		 	subTotal + (element sizeForStorePop: encoder)]