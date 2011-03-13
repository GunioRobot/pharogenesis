typeTableAt: aCharacter
	^typeTable at: aCharacter charCode ifAbsent:[#xLetter]