voice
	"Answer the default voice for the reciever."
	^ Voice voices detect: [ :one | one class == GesturalVoice] ifNone: [super voice]