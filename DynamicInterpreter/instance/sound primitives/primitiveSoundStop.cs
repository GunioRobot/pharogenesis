primitiveSoundStop
	"Stop double-buffered sound output."

	self cCode: 'snd_Stop()'.  "leave rcvr on stack"
	