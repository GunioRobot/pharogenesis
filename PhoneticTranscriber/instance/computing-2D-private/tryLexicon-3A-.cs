tryLexicon: aWord
	| string |
	self lexicon isNil ifTrue: [^ nil].
	string := self lexicon at: aWord asUppercase ifAbsent: [^ nil].
	^ self phonemes transcriptionOf: string asLowercase