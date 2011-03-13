formerOwner: aMorphOrNil
	aMorphOrNil == nil
		ifTrue:[self removeProperty: #formerOwner]
		ifFalse:[self setProperty: #formerOwner toValue: aMorphOrNil]