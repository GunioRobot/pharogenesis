superRequirements
	"Answer the value of superRequirements"

	^ superRequirements isNil
		ifTrue: [IdentitySet new]
		ifFalse: [superRequirements].