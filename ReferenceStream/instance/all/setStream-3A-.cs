setStream: aStream
	"PRIVATE -- Initialization method."

	super setStream: aStream.
	references _ IdentityDictionary new: 4096 * 5.
	objects _ IdentityDictionary new: 4096 * 5.
	fwdRefEnds _ IdentityDictionary new.
	blockers ifNil: [blockers _ IdentityDictionary new].	"keep blockers we just passed in"
