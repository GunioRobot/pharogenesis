startUnorderedList
	"begin an unordered list"
	listLengths add: 0.
	listTypes add: #unordered.
	indentLevel _ indentLevel + 1.
	self setAttributes.
	