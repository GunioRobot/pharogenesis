positionToSecureContentsOf: aStream
	| bytes trusted part1 part2 sig hash dsa okay pos |
	aStream binary.
	pos _ aStream position.
	bytes _ aStream next: 4.
	bytes = 'SPRJ' asByteArray ifFalse:[
		"was not signed"
		aStream position: pos.
		^false].
	part1 _ (aStream nextInto: (LargePositiveInteger basicNew: 20)) normalize.
	part2 _ (aStream nextInto: (LargePositiveInteger basicNew: 20)) normalize.
	sig _ Array with: part1 with: part2.
	hash _ SecureHashAlgorithm new hashStream: aStream.
	dsa _ DigitalSignatureAlgorithm new.
	trusted _ self trustedKeys.
	okay _ (trusted detect:[:key| dsa verifySignature: sig ofMessageHash: hash publicKey: key]
			ifNone:[nil]) notNil.
	aStream position: pos+44.
	^okay