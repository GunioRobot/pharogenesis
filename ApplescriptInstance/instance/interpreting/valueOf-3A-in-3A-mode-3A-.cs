valueOf: aCompiledApplescript in: contextOSAID mode: anInteger
	"Answer text result of executing Applescript aString in context contexOSAID in mode: anInteger"

	| sourceAEDesc sourceOSAID objectOSAID objectAEDesc |
	sourceAEDesc _ AEDesc scptTypeOn: aCompiledApplescript.
	sourceOSAID _ self 
		loadAndDispose: sourceAEDesc 
		mode: anInteger.
	sourceOSAID ifNil: [^nil].
	objectOSAID _ self 
		executeAndDispose: sourceOSAID
		in: contextOSAID
		mode: anInteger.
	objectOSAID ifNil: [^nil].
	objectAEDesc _ self
		displayAndDispose: objectOSAID
		as: 'TEXT'
		mode: anInteger.
	objectAEDesc ifNil: [^nil].
	^objectAEDesc asStringThenDispose