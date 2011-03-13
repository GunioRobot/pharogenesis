handleNewAudioChat2From: dataStream sentBy: senderName ipAddress: ipAddressString

	| newSound seqSound compressed |

	compressed _ self newCompressedSoundFrom: dataStream.
	newSound _ compressed asSound.
"-------an experiment to try
newSound adjustVolumeTo: 7.0 overMSecs: 10
--------"
DebugLog ifNotNil: [
	DebugLog add: {compressed. newSound}.
].
	LiveMessages ifNil: [LiveMessages _ Dictionary new].
	seqSound _ LiveMessages at: ipAddressString ifAbsentPut: [SequentialSound new].
	seqSound isPlaying ifTrue: [
		seqSound
			add: newSound;
			pruneFinishedSounds.
	] ifFalse: [
		seqSound
			initialize;
			add: newSound.
	].
	seqSound isPlaying ifFalse: [seqSound play].