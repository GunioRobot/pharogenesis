word: aWord
	word _ aWord.
	word syllables do: [ :each | each accept: self].
	syllable _ nil