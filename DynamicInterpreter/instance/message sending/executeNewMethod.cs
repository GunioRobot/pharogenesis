executeNewMethod
	"The common case (not a pseudo receiver) is inlined; the other is not."
	self inline: true.
	pseudoReceiver = 0 ifTrue: [
		self executeForNormalReceiver.
	] ifFalse: [
		self assert: pseudoReceiver = newReceiver.
		"One special case: #blockCopy for the activeCachedContext is inlined."
		"This is utterly redundant now that we have MacroPushBlock"
		(primitiveIndex = 80 and: [(self pseudoCachedContextAt: pseudoReceiver) = activeCachedContext]) ifTrue: [
			self primitiveBlockCopy.
			pseudoReceiver _ 0.
		] ifFalse: [
			self executeForCachedReceiver.
		]
	]