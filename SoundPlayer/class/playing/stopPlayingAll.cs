stopPlayingAll
	"Stop playing all sounds."

	PlayerSemaphore critical: [
		ActiveSounds _ ActiveSounds species new].
