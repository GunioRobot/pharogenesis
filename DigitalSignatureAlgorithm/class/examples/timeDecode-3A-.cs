timeDecode: count
	"Example of signing a message and verifying its signature."
	"Note: Secure random numbers are needed for key generation and message signing, but not for signature verification. There is no need to call initRandomFromUser if you are merely checking a signature."
	"DigitalSignatureAlgorithm timeDecode: 20"

	| msg keys sig s dsa |

	dsa _ DigitalSignatureAlgorithm new.
	dsa initRandomFromUser.

	#(1 10 100 1000 10000 100000) do: [ :extraLen |
		s _ String new: extraLen.
		1 to: s size do: [ :i | s at: i put: (Character value: 200 atRandom)].
		msg _ 'This is a test...',s.
		keys _ self testKeySet.
		sig _ self sign: msg privateKey: keys first dsa: dsa.
		"self inform: 'Signature created'."
		self timeDirect: [
			count timesRepeat: [
				(self verify: sig isSignatureOf: msg publicKey: keys last)
					ifFalse: [self error: 'ERROR! Signature verification failed'].
			].
		] as: 'verify msgLen = ',msg size printString count: count
	].
