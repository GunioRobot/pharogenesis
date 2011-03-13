makeFieldGet: getSelector  set: setSelector
	| field fieldHeight |
	fieldHeight _ TextStyle default defaultFont pointSize + 8.
		
		
	field := PluggableTextMorph on: self text: getSelector accept: setSelector.
	field extent: 200@fieldHeight.
	field hideScrollBarsIndefinitely.
	field setProperty: #alwaysAccept toValue: true.
	
	fields ifNil: [ fields _ OrderedCollection new].
	fields add: field.
	
	^field