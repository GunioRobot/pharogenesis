peekBack
	"Return the element at the previous position, without changing position.  Use indirect messages in case self is a StandardFileStream."

	| element |
	element := self oldBack.
	self skip: 1.
	^ element