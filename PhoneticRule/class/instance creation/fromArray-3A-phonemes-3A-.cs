fromArray: anArray phonemes: aPhonemeSet
	^ self new
		left: (anArray at: 1);
		text: (anArray at: 2);
		right: (anArray at: 3);
		phonemes: (aPhonemeSet transcriptionOf: (anArray at: 4)) asArray