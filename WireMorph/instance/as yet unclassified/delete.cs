delete
	pins do: [:p | p removeWire: self].
	pins first isIsolated 
		ifTrue: [pins first removeVariableAccess.
				pins second isIsolated
					ifTrue: [pins second removeModelVariable]]
		ifFalse: [pins second isIsolated
					ifTrue: [pins second removeVariableAccess]
					ifFalse: [pins second addModelVariable]].
	super delete