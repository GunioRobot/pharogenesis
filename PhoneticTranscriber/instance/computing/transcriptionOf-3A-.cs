transcriptionOf: aString
	"Answer the phonetic transcription of the word in aString."
	| rule string index transcription stressed |
	(transcription _ self tryLexicon: aString) isNil ifFalse: [^ transcription].
	transcription _ OrderedCollection new.
	string _ ' ', aString,' '.
	index _ 2.
	[index < string size] whileTrue: [
		rule _ self rules
			detect: [ :one | one matches: string at: index]
			ifNone: [].
		rule isNil
			ifTrue: ["unmatched character" index _ index+1]
			ifFalse: [index _ index + rule text size.
					transcription addAll: rule phonemes]].
	stressed _ false.
	^ transcription collect: [ :each |
		(stressed not and: [each isVowel or: [each isDiphthong]])
			ifTrue: [stressed _ true. each stressed: 1] ifFalse: [each]]