testExamplesFromDisk
	"verify messages from file on disk"
	"Note: Secure random numbers are needed for key generation and message signing, but not for signature verification. There is no need to call initRandomFromUser if you are merely checking a signature."
	"DigitalSignatureAlgorithm testExamplesFromDisk"

	| msg  sig file publicKey |

	file _ FileStream oldFileNamed: 'dsa.test.out'.
	[
		[file atEnd] whileFalse: [
			sig _ file nextChunk.
			msg _ file nextChunk.
			publicKey _ Compiler evaluate: file nextChunk.
			(self verify: sig isSignatureOf: msg publicKey: publicKey) ifTrue: [
				Transcript show: 'SUCCESS: ',msg; cr.
			] ifFalse: [
				self error: 'ERROR! Signature verification failed'
			].
		].
	] ensure: [file close]
