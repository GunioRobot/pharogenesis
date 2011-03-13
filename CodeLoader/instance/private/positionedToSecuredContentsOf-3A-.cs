positionedToSecuredContentsOf: aStream
	"Private - return the 'secured' part of the given stream, e.g., the actual contents without the verification checksum. If the verification fails return nil (since there is no secured contents)."

	| hash signature part1 part2 dsa okay |

	"No key, no security..."
	publicKey == nil
		ifTrue: [^true].
	aStream position: 0.
	aStream binary.
	part1 _ aStream nextInto: (LargePositiveInteger basicNew: 20).
	part2 _ aStream nextInto: (LargePositiveInteger basicNew: 20).
	signature _ Array with: part1 with: part2.
	hash _ SecureHashAlgorithm new hashStream: aStream.
	dsa _ DigitalSignatureAlgorithm new.
	okay _ dsa verifySignature: signature ofMessageHash: hash publicKey: publicKey.
	okay
		ifFalse: [^false].
	aStream ascii.
	aStream position: 40.
	^true