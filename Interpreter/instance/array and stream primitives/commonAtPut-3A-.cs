commonAtPut: stringy
	"See the comment in commonAt:."

	| value valToStore index rcvr |
	self inline: true.
	value _ valToStore _ self stackTop.
	index _ self stackValue: 1.
	rcvr _ self stackValue: 2.
	(self isIntegerObject: index) & (self isIntegerObject: rcvr) not ifTrue: [
		index _ self integerValueOf: index.
		stringy ifTrue: [valToStore _ self asciiOfCharacter: value].
		self stObject: rcvr at: index put: valToStore.
	] ifFalse: [
		successFlag _ false.
	].
	successFlag ifTrue: [
		self pop: 3 thenPush: value.
	] ifFalse: [
		stringy
			ifTrue: [self failSpecialPrim: 64]
			ifFalse: [self failSpecialPrim: 61].
	].