repeatWithGCIf: testBlock
	| ans |
	"run the receiver, and if testBlock returns true, garbage collect and run the receiver again"
	ans _ self value.
	(testBlock value: ans) ifTrue: [ Smalltalk garbageCollect. ans _ self value ].
	^ans