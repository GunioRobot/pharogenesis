encodeVariable: name ifUnknown: action
	| varNode |
	varNode _ 
		scopeTable 
			at: name
			ifAbsent: 
				[self lookupInPools: name 
					ifFound: [:assoc | ^self global: assoc name: name].
				^action value].
	^varNode