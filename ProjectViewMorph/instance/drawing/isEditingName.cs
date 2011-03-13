isEditingName

	| nameMorph |
	nameMorph _ self findA: UpdatingStringMorph.
	nameMorph ifNil: [^false].

	^nameMorph hasFocus
