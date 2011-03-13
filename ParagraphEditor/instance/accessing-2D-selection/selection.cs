selection
	"Answer the text in the paragraph that is currently selected."

	| t |
	t := paragraph text copyFrom: self startIndex to: self stopIndex - 1.
	t string isOctetString ifTrue: [t asOctetStringText].
	^ t.
