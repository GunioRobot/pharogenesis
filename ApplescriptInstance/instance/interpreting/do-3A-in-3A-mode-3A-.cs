do: aString in: contextOSAID mode: anInteger
	"Answer text result of executing Applescript aString in context contexOSAID in mode: anInteger"

	| source object result |
	source _ AEDesc textTypeOn: aString.
	object _ AEDesc new.
	result _ self	
		primOSADoScript: source
		in: contextOSAID
		mode: anInteger
		resultType: (DescType of: 'TEXT')
		to: object.
	source dispose.
	result isZero ifFalse: [^nil].
	^object asStringThenDispose