scopeHas: varName ifTrue: assocBlock
	"Look up the first argument, varName, in the context of the receiver. If it is there,
	pass the association to the second argument, assocBlock, and answer true."

	| assoc |
	"First look in classVar dictionary."
	(assoc _ self classPool associationAt: varName ifAbsent: []) == nil
		ifFalse: [assocBlock value: assoc.
				^ true].

	"Next look in shared pools."
	self sharedPools do: 
		[:pool | 
		assoc _ pool associationAt: varName ifAbsent: [
			"String key hack from Hypersqueak now used in Wonderland  **Eliminate this**"
			pool associationAt: varName asString ifAbsent: []].
		assoc == nil ifFalse: 
				[assocBlock value: assoc.
				^true]].

	"Next look in declared environment."
	(assoc _ self environment associationAtOrAbove: varName ifAbsent: [nil]) == nil
		ifFalse: [assocBlock value: assoc.
				^ true].

	"Finally look higher up the superclass chain and fail at the end."
	superclass == nil
		ifTrue: [^ false]
		ifFalse: [^ superclass scopeHas: varName ifTrue: assocBlock].

