encodeVariable: name sourceRange: range ifUnknown: action
	| varNode |
	varNode _ scopeTable at: name
			ifAbsent: 
				[(self lookupInPools: name 
					ifFound: [:assoc | varNode _ self global: assoc name: name])
					ifTrue: [varNode]
					ifFalse: [action value]].
	range ifNotNil: [
		name first canBeGlobalVarInitial ifTrue:
			[globalSourceRanges addLast: { name. range. false }]. ].

	(varNode isTemp and: [varNode scope < 0]) ifTrue: [
		OutOfScopeNotification signal ifFalse: [ ^self notify: 'out of scope'].
	].
	^ varNode