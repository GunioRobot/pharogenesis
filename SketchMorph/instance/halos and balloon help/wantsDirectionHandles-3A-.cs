wantsDirectionHandles: aBool
	aBool == (Preferences showDirectionHandles or:[Preferences showDirectionForSketches])
		ifTrue:[self removeProperty: #wantsDirectionHandles]
		ifFalse:[self setProperty: #wantsDirectionHandles toValue: aBool].