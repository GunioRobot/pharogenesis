lookupInPools: varName ifFound: assocBlock

	Symbol hasInterned: varName ifTrue:[:sym|
		(class bindingOf: sym) ifNotNilDo:[:assoc| 
			assocBlock value: assoc.
			^true].
		(Preferences valueOfFlag: #lenientScopeForGlobals)  "**Temporary**"
			ifTrue: [^ Smalltalk lenientScopeHas: sym ifTrue: assocBlock]
			ifFalse: [^ false]].
	(class bindingOf: varName) ifNotNilDo:[:assoc|
		assocBlock value: assoc.
		^true].
	^false