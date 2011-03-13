findString: subString startingAt: start 
	"Answer the index of subString within the receiver, starting at start. If 
	the receiver does not contain subString, answer 0."

	^ self indexOfSubCollection: subString startingAt: start
		ifAbsent: [0]