initFor: className revertable: isRevertable

	inForce _ isRevertable.
	changeTypes _ IdentitySet new.
	methodChanges _ IdentityDictionary new.
	priorName _ thisName _ className.
	revertable _ isRevertable and: [self realClass notNil].
	revertable ifTrue:
		[priorMD _ self realClass methodDict copy.
		priorOrganization _ self realClass organization deepCopy].
