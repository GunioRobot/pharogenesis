setStream: aStream
	"PRIVATE -- Initialization method."

	super setStream: aStream.
	references _ IdentityDictionary new: 4096 * 5.
	objects _ IdentityDictionary new: 4096 * 5.
	fwdRefEnds _ IdentityDictionary new.
	skipping _ IdentitySet new.
	insideASegment _ false.
	blockers ifNil: [blockers _ IdentityDictionary new].	"keep blockers we just passed in"
