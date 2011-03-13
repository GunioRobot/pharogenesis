shortSummary
	"Answer a short summary of the receiver."

	|suffix|
	suffix := self fromSource = self toSource
		ifTrue: [' (revision changed)']
		ifFalse: [''].
	^(self isClassPatch
		ifTrue: [self definition summary]
		ifFalse: [self definition isOrganizationDefinition
				ifTrue: [self definition description last]
				ifFalse: [self definition isMethodDefinition
					ifTrue: [self definition selector asString]
					ifFalse: [self definition summary]]]), suffix