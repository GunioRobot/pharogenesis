fontSizesFor: aName
	| aStyle |
	aStyle _ TextStyle named: aName asSymbol.
	aStyle ifNil: [self halt: 'not found'].
	^ aStyle fontArray collect: [:f | f height]

"Utilities fontSizesFor: 'Palatino'"