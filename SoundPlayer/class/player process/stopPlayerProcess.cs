stopPlayerProcess
	"Stop the sound player process."
	"SoundPlayer stopPlayerProcess"

	PlayerProcess == nil ifFalse: [PlayerProcess terminate].
	PlayerProcess _ nil.
	self primSoundStop.
	ActiveSounds _ OrderedCollection new.
	Buffer _ nil.
	PlayerSemaphore _ Semaphore forMutualExclusion.
	ReadyForBuffer ifNotNil:
		[Smalltalk unregisterExternalObject: ReadyForBuffer].
	ReadyForBuffer _ nil.
