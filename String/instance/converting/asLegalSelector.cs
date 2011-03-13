asLegalSelector
	| toUse |
	toUse _ ''.
	self do:
		[:char | char isAlphaNumeric ifTrue: [toUse _ toUse copyWith: char]].
	(self size == 0 or: [self first isLetter not])
		ifTrue:		[toUse _ 'v', toUse].

	^ toUse withFirstCharacterDownshifted

"'234znak 43 ) 2' asLegalSelector"