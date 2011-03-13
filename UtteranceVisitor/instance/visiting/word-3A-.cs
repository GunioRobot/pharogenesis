word: aWord
	word := aWord.
	word syllables do: [ :each | each accept: self].
	syllable := nil