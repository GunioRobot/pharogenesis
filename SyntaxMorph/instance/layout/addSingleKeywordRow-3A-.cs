addSingleKeywordRow: aStringLikeItem

	| row sMorph modifiedString |

	(row _ self class row: #text on: nil) borderWidth: 1.

	modifiedString _ self substituteKeywordFor: aStringLikeItem.
	sMorph _ self addString: modifiedString special: true.
	sMorph font: (self fontToUseForSpecialWord: modifiedString).
	modifiedString = aStringLikeItem ifFalse: [
		sMorph setProperty: #syntacticallyCorrectContents toValue: aStringLikeItem].

	row addMorph: sMorph.
	self addMorphBack: row.
	^row