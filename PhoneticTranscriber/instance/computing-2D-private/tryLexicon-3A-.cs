tryLexicon: aWord
	| string |
	self lexicon isNil ifTrue: [^ nil].
	string _ self lexicon at: aWord asUppercase ifAbsent: [^ nil].
	^ self phonemes transcriptionOf: string asLowercase