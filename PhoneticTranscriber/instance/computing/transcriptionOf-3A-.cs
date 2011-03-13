transcriptionOf: aString
	"Answer the phonetic transcription of the word in aString."
	| rule string index transcription stressed |
	(transcription := self tryLexicon: aString) isNil ifFalse: [^ transcription].
	transcription := OrderedCollection new.
	string := ' ', aString,' '.
	index := 2.
	[index < string size] whileTrue: [
		rule := self rules
			detect: [ :one | one matches: string at: index]
			ifNone: [].
		rule isNil
			ifTrue: ["unmatched character" index := index+1]
			ifFalse: [index := index + rule text size.
					transcription addAll: rule phonemes]].
	stressed := false.
	^ transcription collect: [ :each |
		(stressed not and: [each isVowel or: [each isDiphthong]])
			ifTrue: [stressed := true. each stressed: 1] ifFalse: [each]]