pointSizesFor: aName
	^ (self fontArrayForStyle: aName) collect: [:f | f pointSize]

"Utilities pointSizesFor: 'Palatino'"