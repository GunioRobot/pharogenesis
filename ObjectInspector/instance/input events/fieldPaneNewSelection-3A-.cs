fieldPaneNewSelection: fieldString
	fieldIndex _ fieldList indexOf: fieldString ifAbsent: [0].
	fieldIndex = 0 ifTrue: [^ self].
	valuePane scroller removeAllMorphs;
		addMorph: (TextMorph new contents: self fieldValue printString asText)