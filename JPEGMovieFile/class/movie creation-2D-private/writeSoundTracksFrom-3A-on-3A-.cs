writeSoundTracksFrom: mpegFile on: aBinaryStream
	"Convert and write the sound tracks from the given MPEG file to given stream. Answer a collection of sound track offsets."
	"Details: Currently converts at most one sound track; only the left channel of a stereo movie will be converted."

	| soundtrackCount soundTrackOffsets snd |
	soundtrackCount _ mpegFile hasAudio ifTrue: [1] ifFalse: [0].
	soundTrackOffsets _ Array new: soundtrackCount.
	1 to: soundtrackCount do: [:i |
		soundTrackOffsets at: i put: aBinaryStream position.
		snd _ mpegFile audioPlayerForChannel: i.
		snd storeSunAudioOn: aBinaryStream compressionType: 'mulaw'.
		snd closeFile].
	^ soundTrackOffsets
