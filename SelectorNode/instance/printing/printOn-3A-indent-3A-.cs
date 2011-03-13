printOn: aStream indent: level 
	aStream withStyleFor: #keyword
		do: [key == nil
				ifTrue: [aStream nextPutAll: '<key==nil>']
				ifFalse: [aStream nextPutAll: key]]