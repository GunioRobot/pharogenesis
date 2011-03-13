stringForPackageNames: depends 
	| first |
	first := true.
	^String streamContents: 
			[:str | 
			depends do: 
					[:depName | 
					first ifTrue: [first := false] ifFalse: [str nextPutAll: ', '].
					str nextPutAll: depName]]