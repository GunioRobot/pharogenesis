nextPut: aChar
	attributesChanged 
		ifTrue: [ 
			attributeRuns addLast: currentAttributes.
			attributesChanged _ false ]
		ifFalse: [
			attributeRuns  repeatLastIfEmpty: [ OrderedCollection new ] ].
	characters nextPut: aChar