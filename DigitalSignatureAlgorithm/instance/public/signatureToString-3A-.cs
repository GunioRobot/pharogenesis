signatureToString: aSignature
	"Answer a string representation of the given signature. This string can be parsed using the stringToSignature: method."

	| s hex |
	s _ WriteStream on: (String new: 2000).
	s nextPutAll: '[DSA digital signature '.
	hex _ aSignature first printStringBase: 16.
	s nextPutAll: (hex copyFrom: 4 to: hex size).
	s space.
	hex _ aSignature second printStringBase: 16.
	s nextPutAll: (hex copyFrom: 4 to: hex size).
	s nextPutAll: ']'.
	^ s contents
