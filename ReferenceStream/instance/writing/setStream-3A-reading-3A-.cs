setStream: aStream reading: isReading
	"PRIVATE -- Initialization method."

	super setStream: aStream reading: isReading.
	"isReading ifFalse: [  when we are sure"
	references _ IdentityDictionary new: 4096 * 5.
	isReading ifTrue: [
		objects _ IdentityDictionary new: 4096 * 5.
		skipping _ IdentitySet new.
		insideASegment _ false.
		fwdRefEnds _ IdentityDictionary new].
	blockers ifNil: [blockers _ IdentityDictionary new].	"keep blockers we just passed in"
