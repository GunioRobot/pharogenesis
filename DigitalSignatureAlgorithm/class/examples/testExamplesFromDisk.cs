testExamplesFromDisk
	"verify messages from file on disk"
	"Note: Secure random numbers are needed for key generation and message signing, but not for signature verification. There is no need to call initRandomFromUser if you are merely checking a signature."
	"DigitalSignatureAlgorithm testExamplesFromDisk"

	| msg  sig file publicKey |

	file := FileStream readOnlyFileNamed: 'dsa.test.out'.
	[
		[file atEnd] whileFalse: [
			sig := file nextChunk.
			msg := file nextChunk.
			publicKey := Compiler evaluate: file nextChunk.
			(self verify: sig isSignatureOf: msg publicKey: publicKey) ifTrue: [
				Transcript show: 'SUCCESS: ',msg; cr.
			] ifFalse: [
				self error: 'ERROR! Signature verification failed'
			].
		].
	] ensure: [file close]
