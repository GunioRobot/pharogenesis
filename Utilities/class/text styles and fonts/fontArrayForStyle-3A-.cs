fontArrayForStyle: aName
	^ ((TextStyle named: aName asSymbol) ifNil: [self error: 'text style not found']) fontArray

"Utilities fontArrayForStyle: 'Palatino'"
"Utilities fontPointSizesFor: 'Elmo'"