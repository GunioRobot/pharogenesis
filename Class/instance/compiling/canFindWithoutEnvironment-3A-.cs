canFindWithoutEnvironment: varName
	"This method is used for analysis of system structure -- see senders."
	"Look up varName, in the context of the receiver. Return true if it can be found without using the declared environment."

	| assoc |
	"First look in classVar dictionary."
	(assoc _ self classPool associationAt: varName ifAbsent: []) == nil
		ifFalse: [^ true].

	"Next look in shared pools."
	self sharedPools do: 
		[:pool | 
		assoc _ pool associationAt: varName ifAbsent: [
			"Hideous string key hack from Hypersqueak now used in Wonderland"
			pool associationAt: varName asString ifAbsent: []].
		assoc == nil ifFalse: 
				[^ true]].

	"Finally look higher up the superclass chain and fail at the end."
	superclass == nil
		ifTrue: [^ false]
		ifFalse: [^ superclass scopeHas: varName ifTrue: [:ignored]].

