fontWidthsFor: aName
	^ (self fontArrayForStyle: aName) collect: [:f | f maxWidth]

"Utilities fontWidthsFor: 'ComicPlain'"