startOrderedList
	"begin an ordered list"
	listLengths add: 0.
	listTypes add: #ordered.
	indentLevel _ indentLevel + 1.
	self setAttributes.
	