makeFieldRowNamed: fieldName  getSelector: getSelector setSelector: setSelector isPassword: isPassword for: model
	| row field |
	row _ AlignmentMorph newRow.
	row color: Color transparent.
	row cellInset: 3@0.
	
	field _ self makeFieldGet: getSelector set: setSelector for: model.
	isPassword ifTrue:[
		field font: (StrikeFont passwordFontSize: TextStyle default defaultFont pointSize) ].

	row addMorph: (StringMorph contents: fieldName).
	row addMorphBack: field.

	^row

