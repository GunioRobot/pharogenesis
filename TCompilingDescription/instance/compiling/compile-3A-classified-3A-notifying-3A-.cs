compile: text classified: category notifying: requestor
	| stamp |
	stamp _ self acceptsLoggingOfCompilation ifTrue: [Utilities changeStamp] ifFalse: [nil].
	^ self compile: text classified: category
		withStamp: stamp notifying: requestor