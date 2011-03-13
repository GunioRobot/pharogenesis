wellFormedInstanceVariableNameFrom: aString
	"Answer a legal instance variable name, derived from aString"

	| cleansedString |
	cleansedString _ aString select: [:ch | ch isDigit or: [ch isLetter]].
	(cleansedString size == 0 or: [cleansedString first isDigit])
		ifTrue: [cleansedString _ 'a', cleansedString]
		ifFalse:	[cleansedString _ cleansedString withFirstCharacterDownshifted].

	[self isLegalInstVarName: cleansedString] whileFalse:
		[cleansedString _ cleansedString, 'x'].
	^ cleansedString

"Utilities wellFormedInstanceVariableNameFrom:  '234 xx\ Uml /ler42342380-4'"