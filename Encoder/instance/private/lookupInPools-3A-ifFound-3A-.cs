lookupInPools: varName ifFound: assocBlock

	Symbol hasInterned: varName ifTrue:
		[:sym | (class scopeHas: sym ifTrue: assocBlock) ifTrue: [^ true].
		(Preferences valueOfFlag: #lenientScopeForGlobals)  "**Temporary**"
			ifTrue: [^ Smalltalk lenientScopeHas: sym ifTrue: assocBlock]
			ifFalse: [^ false]].
	^ class scopeHas: varName ifTrue: assocBlock.  "Maybe a string in a pool  **Eliminate this**"