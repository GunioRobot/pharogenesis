scopeHas: varName ifTrue: assocBlock 
	"Look up the first argument, varName, in the context of the receiver. If it is there,
	pass the association to the second argument, assocBlock, and answer true.
	Else answer false.
	9/11/96 tk: Allow key in shared pools to be a string for HyperSqueak"

	| assoc pool |
	assoc _ self classPool associationAt: varName ifAbsent: [].
	assoc == nil
		ifFalse: 
			[assocBlock value: assoc.
			^true].
	self sharedPools do: 
		[:pool | 
		varName = #Textual ifTrue: [self halt].
		assoc _ pool associationAt: varName ifAbsent: [
			pool associationAt: varName asString ifAbsent: []].
		assoc == nil
			ifFalse: 
				[assocBlock value: assoc.
				^true]].
	superclass == nil
		ifTrue: 
			[assoc _ Smalltalk associationAt: varName ifAbsent: [].
			assoc == nil
				ifFalse: 
					[assocBlock value: assoc.
					^true].
			^false].
	^superclass scopeHas: varName ifTrue: assocBlock