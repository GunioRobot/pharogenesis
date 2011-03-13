execute: anOperationClass do: aBlock
	| operation |
	^ GoferVersionCache during: [
		operation := anOperationClass on: self.
		aBlock isNil
			ifFalse: [ aBlock value: operation ].
		operation execute ]