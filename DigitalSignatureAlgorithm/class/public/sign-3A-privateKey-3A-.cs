sign: aStringOrStream privateKey: privateKey
	"Sign the given message (a stream or string) and answer a signature string."
	"Note: Unguessable random numbers are needed for message signing. The user will be prompted to type a really long random string (two or three lines) to initialize the random number generator before signing a message. A different random string should be typed for every session; it is not a password and we wish to produce different random number streams."

	| dsa hasher h sig |
	dsa _ DigitalSignatureAlgorithm new.
	dsa initRandomFromUser.
	hasher _ SecureHashAlgorithm new.
	(aStringOrStream class isBytes)
		ifTrue: [h _ hasher hashMessage: aStringOrStream]
		ifFalse: [h _ hasher hashStream: aStringOrStream].
	sig _ dsa computeSignatureForMessageHash: h privateKey: privateKey.
	^ dsa signatureToString: sig
