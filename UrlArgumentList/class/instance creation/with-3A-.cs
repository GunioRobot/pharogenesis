with: argAssoc
	| argList |
	argList _ self new.
	argList add: argAssoc key value: argAssoc value.
	^argList