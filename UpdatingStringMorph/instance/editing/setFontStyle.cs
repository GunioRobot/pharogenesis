setFontStyle
	| aList reply style |
	aList _ (TextConstants select: [:anItem | anItem isKindOf: TextStyle])
			keys asOrderedCollection.
	reply _ (SelectionMenu labelList: aList selections: aList) startUp.
	reply ~~ nil ifTrue:
		[(style _ TextStyle named: reply) ifNil: [self beep. ^ true].
		self font: (style defaultFont)]