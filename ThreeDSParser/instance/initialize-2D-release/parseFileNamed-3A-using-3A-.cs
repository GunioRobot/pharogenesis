parseFileNamed: aString using: spec
	"Read the 3DS file from the given stream"
	self classSpec: spec.
	^self parseFileNamed: aString