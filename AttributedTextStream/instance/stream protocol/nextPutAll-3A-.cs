nextPutAll: aString
	"add an entire string with the same attributes"
	attributesChanged 
		ifTrue: [ attributeRuns addLast: currentAttributes times: aString size.
			attributesChanged _ false. ]
		ifFalse: [ attributeRuns repeatLast: aString size  ifEmpty: [ OrderedCollection new ] ].
	characters nextPutAll: aString.