loadSound: soundName

	| snd |
	snd _ SoundService default soundNamed: soundName.
	snd ifNotNil: [self sendMessageToCostume: #loadSound: with: snd].
