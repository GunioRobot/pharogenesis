perform: sel orSendTo: otherObject
	(self respondsTo: sel) ifTrue: [self perform: sel] ifFalse: [otherObject perform: sel]