hasUnacceptedInput
	"Answer if the receiver bears unaccepted input.  3/13/96 sw"

	^ (self respondsTo: #isUnlocked) and: [self isUnlocked not]