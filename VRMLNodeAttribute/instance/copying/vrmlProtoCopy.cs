vrmlProtoCopy
	| valueCopy |
	self containsNodes
		ifTrue:[valueCopy := self vrmlProtoCopyValues]
		ifFalse:[valueCopy := self value shallowCopy].
 	^self shallowCopy value: valueCopy