endOrderedList
	"end an ordered list"
	listLengths removeLast.
	listTypes removeLast.
	indentLevel _ indentLevel - 1.
	self setAttributes. 

	self ensureNewlines: 1.
	