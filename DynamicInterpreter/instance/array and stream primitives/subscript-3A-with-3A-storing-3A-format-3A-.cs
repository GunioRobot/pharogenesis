subscript: array with: index storing: oopToStore format: fmt
	"Note: This method assumes that the index is within bounds!"

	| valueToStore |
	self inline: true.
	fmt < 4 ifTrue: [  "pointer type objects"
		self storePointer: index - 1 ofObject: array withValue: oopToStore.
	] ifFalse: [
		fmt < 8 ifTrue: [  "long-word type objects"
			valueToStore _ self positive32BitValueOf: oopToStore.
			successFlag ifTrue:
				[self storeWord: index - 1 ofObject: array withValue: valueToStore].
		] ifFalse: [  "byte-type objects"
			(self isIntegerObject: oopToStore) ifFalse: [successFlag _ false].
			valueToStore _ self integerValueOf: oopToStore.
			((valueToStore >= 0) and: [valueToStore <= 255]) ifFalse: [successFlag _ false].
			successFlag ifTrue:
				[self storeByte: index - 1 ofObject: array withValue: valueToStore].
		].
	].