verify: signatureString isSignatureOf: aStringOrStream publicKey: publicKey
	"Answer true if the given signature string signs the given message (a stream or string)."
	"Note: Random numbers are not needed for signature verification; thus, there is no need to call initRandomFromUser before verifying a signature."

	| dsa hasher h sig |
	dsa _ DigitalSignatureAlgorithm new.
	hasher _ SecureHashAlgorithm new.
	(aStringOrStream class isBytes)
		ifTrue: [h _ hasher hashMessage: aStringOrStream]
		ifFalse: [h _ hasher hashStream: aStringOrStream].
	sig _ dsa stringToSignature: signatureString.
	^ dsa verifySignature: sig ofMessageHash: h publicKey: publicKey
