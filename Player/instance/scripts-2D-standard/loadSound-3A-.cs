loadSound: soundName

	| snd |
	snd _ SampledSound soundNamed: soundName.
	snd ifNotNil: [self sendMessageToCostume: #loadSound: with: snd].
