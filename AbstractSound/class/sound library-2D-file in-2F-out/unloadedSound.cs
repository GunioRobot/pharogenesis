unloadedSound
	"Answer a sound to be used as the place-holder for sounds that have been unloaded."

	UnloadedSnd ifNil: [UnloadedSnd _ UnloadedSound default copy].
	^ UnloadedSnd
