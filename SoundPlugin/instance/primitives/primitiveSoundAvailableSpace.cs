primitiveSoundAvailableSpace
	"Returns the number of sample frames of available sound output buffer space."

	| frames |
	self primitive: 'primitiveSoundAvailableSpace'.
	frames _ self cCode: 'snd_AvailableSpace()'.  "-1 if sound output not started"
	interpreterProxy success: frames >= 0.
	^frames asPositiveIntegerObj