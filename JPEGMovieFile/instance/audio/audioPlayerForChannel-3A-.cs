audioPlayerForChannel: anInteger
	"Answer a streaming sound for playing the audio channel with the given index."

	((anInteger >= 1) & (anInteger <= soundtrackOffsets size)) ifFalse: [^ nil].
	^ StreamingMonoSound
		onFileNamed: file fullName
		headerStart: (soundtrackOffsets at: anInteger)
