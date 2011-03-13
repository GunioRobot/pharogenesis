phrase: aPhrase
	phrase := aPhrase.
	phrase words do: [ :each | each accept: self].
	word := syllable := nil