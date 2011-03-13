after: oldObject 
	"Answer the element after oldObject. If the receiver does not contain 
	oldObject or if the receiver contains no elements after oldObject, create 
	an error notification."
	| index |
	index _ self find: oldObject.
	index = lastIndex
		ifTrue: [^self errorLastObject]
		ifFalse: [^array at: index + 1]