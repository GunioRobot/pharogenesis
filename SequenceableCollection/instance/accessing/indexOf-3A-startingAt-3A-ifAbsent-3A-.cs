indexOf: anElement startingAt: start ifAbsent: exceptionBlock
	"Answer the index of anElement within the receiver. If the receiver does 
	not contain anElement, answer the result of evaluating the argument, 
	exceptionBlock."
	start to: self size do:
		[:i | (self at: i) = anElement ifTrue: [^ i]].
	^ exceptionBlock value