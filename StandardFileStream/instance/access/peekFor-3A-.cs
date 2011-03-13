peekFor: item 
	"Answer false and do not move over the next element if it is not equal to 
	the argument, anObject, or if the receiver is at the end. Answer true 
	and increment the position for accessing elements, if the next element is 
	equal to anObject..  Copied over from HFS versino.  2/14/96 sw"

	| next |

	self atEnd ifTrue: [^ false].
	next _ self next.
	item = next ifTrue: [^ true].
	self skip: -1.
	^ false