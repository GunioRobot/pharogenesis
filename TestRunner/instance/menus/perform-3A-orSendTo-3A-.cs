perform: aSelector orSendTo: otherTarget
	^((self respondsTo: aSelector) ifTrue: [ self ] ifFalse: [ otherTarget ]) perform: aSelector
