formerPosition: formerPosition 
	formerPosition isNil 
		ifTrue: [self removeProperty: #formerPosition]
		ifFalse: [self setProperty: #formerPosition toValue: formerPosition]