lastCheckpointNumberOnDisk
	"Return the last checkpoint number on disk."

	^(self nextFileNameForCheckPoint findTokens: '.') second asNumber - 1