cursor
	"Answer the receiver's logical cursor position"

	| loc |
	loc _ self valueOfProperty: #textCursorLocation  ifAbsentPut: [1].
	loc _ loc min: text string size.
	^ loc rounded
	