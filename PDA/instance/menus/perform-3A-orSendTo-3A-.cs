perform: selector orSendTo: otherTarget
	"This should be the default in Object"

	(self respondsTo: selector)
		ifTrue: [^ self perform: selector]
		ifFalse: [^ otherTarget perform: selector]