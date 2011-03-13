parse

	| styleName |
	styleNameIn := self splitBadTokensIn: styleNameIn.
	combinedName := styleNameIn withBlanksTrimmed.
	tokens := self tokenize: combinedName.
	self extractUpright.
	styleName := combinedName.
	combinedName := familyNameIn withBlanksTrimmed.
	self addStyleNameToCombinedName: styleName..
	tokens := self tokenize: combinedName.
	self extractSlant.
	tokens := self tokenize: combinedName.
	self extractStretch.
	tokens := self tokenize: combinedName.
	self extractWeight.
	