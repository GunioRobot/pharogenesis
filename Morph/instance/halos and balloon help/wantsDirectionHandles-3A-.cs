wantsDirectionHandles: aBool
	aBool == Preferences showDirectionHandles
		ifTrue:[self removeProperty: #wantsDirectionHandles]
		ifFalse:[self setProperty: #wantsDirectionHandles toValue: aBool].
