hasInOwnerChain: aMorph
	"If aMorph is somewhere in the receiver's owner chain, respond true"
	self eachStepInOwnerChainDo:
		[:anOwner | anOwner == aMorph ifTrue: [^ true]].
	^ false