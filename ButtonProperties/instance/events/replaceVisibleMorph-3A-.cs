replaceVisibleMorph: aNewMorph

	| old oldOwner oldText |

	old _ visibleMorph.
	oldText _ self currentTextInButton.
	self visibleMorph: nil.
	old buttonProperties: nil.
	aNewMorph buttonProperties: self.
	self visibleMorph: aNewMorph.
	self addTextToButton: oldText.
	oldOwner _ old owner ifNil: [^self].
	oldOwner replaceSubmorph: old by: aNewMorph.