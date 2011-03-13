makeFieldGet: getSelector  set: setSelector  for: model
	| field fieldHeight |
	fieldHeight _ TextStyle default defaultFont pointSize + 8.
		
		
	field := PluggableTextMorph on: model text: getSelector accept: setSelector.
	field height: fieldHeight.
	field hResizing: #spaceFill.
	field hideScrollBarsIndefinitely.
	field setProperty: #alwaysAccept toValue: true.

	model noteField: field.

	^field