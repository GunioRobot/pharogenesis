phrase: aPhrase
	phrase _ aPhrase.
	phrase words do: [ :each | each accept: self].
	word _ syllable _ nil