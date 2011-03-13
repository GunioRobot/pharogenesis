processEnvelopeFrom: data
	| env |
	env := FlashSoundEnvelope new.
	env mark44: data nextULong.
	env level0: data nextWord.
	env level1: data nextWord.
	^env