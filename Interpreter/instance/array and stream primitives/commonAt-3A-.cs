commonAt: stringy
	"This version of at: is called from the special byteCode, from
	primitiveAt, and from primStringAt.  The boolean 'stringy'
	indicates that the result should be converted to a Character."

	| index rcvr result |
	self inline: true.
	index _ self stackTop.
	rcvr _ self stackValue: 1.
	(self isIntegerObject: index) & (self isIntegerObject: rcvr) not ifTrue: [
		index _ self integerValueOf: index.
		result _ self stObject: rcvr at: index.
		(stringy and: [successFlag]) ifTrue: [result _ self characterForAscii: result].
	] ifFalse: [
		successFlag _ false.
	].
	successFlag ifTrue: [
		self pop: 2 thenPush: result.
	] ifFalse: [
		stringy
			ifTrue: [self failSpecialPrim: 63]
			ifFalse: [self failSpecialPrim: 60].
	].