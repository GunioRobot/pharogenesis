fontPointSizesFor: aName
	^ (self fontArrayForStyle: aName) collect: [:f | f pointSize]

"Utilities fontPointSizesFor: 'Palatino'"
"Utilities fontPointSizesFor: 'Elmo'"