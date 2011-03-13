formerPosition: formerPosition
	formerPosition == nil
		ifTrue:[self removeProperty: #formerPosition]
		ifFalse:[self setProperty: #formerPosition toValue: formerPosition]