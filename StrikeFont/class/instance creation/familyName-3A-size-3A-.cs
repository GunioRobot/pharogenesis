familyName: aName size: aSize
	| aStyle |
	(aStyle _ TextStyle named: aName asSymbol)
		ifNil: [self halt: 'Error: font ', aName, ' not found.'].
	^ aStyle fontOfSize: aSize