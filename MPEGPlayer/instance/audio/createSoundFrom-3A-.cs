createSoundFrom: aStream 
	| snds channels |
	
	snds _ OrderedCollection new.
	channels _ self audioChannels: 0.
	1 to: channels do: [:c | snds add: (self readSoundChannel: c - 1 stream: aStream)].
	channels = 1
		ifTrue:[^ MixedSound new
				add: (snds at: 1) pan: 0.5 volume: volume;
				
				yourself]
		ifFalse: [
			^ MixedSound new
				add: (snds at: 1) pan: 0.0 volume: volume;
				add: (snds at: 2) pan: 1.0 volume: volume;
				yourself].