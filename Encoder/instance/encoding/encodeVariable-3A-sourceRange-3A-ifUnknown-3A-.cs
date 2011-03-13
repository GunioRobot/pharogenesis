encodeVariable: name sourceRange: range ifUnknown: action
	| varNode |
	varNode _ scopeTable at: name
			ifAbsent: 
				[(self lookupInPools: name 
					ifFound: [:assoc | varNode _ self global: assoc name: name])
					ifTrue: [varNode]
					ifFalse: [action value]].
	range ifNotNil: [
		name first isUppercase ifTrue:
			[globalSourceRanges addLast: { name. range. false }]. ].

	(varNode isTemp and: [varNode scope < 0]) ifTrue: [^self notify: 'out of scope'].

	^ varNode