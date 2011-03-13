stopPlayerProcess
	"Stop the sound player process."
	"SoundPlayer stopPlayerProcess"

	self primSoundStop.
	PlayerProcess == nil ifFalse: [ PlayerProcess terminate ].
	PlayerProcess _ nil.
	PlayerSemaphore _ nil.
	Buffer _ nil.
	ActiveSounds _ OrderedCollection new.
