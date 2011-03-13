printOn: aStream indent: level 
	aStream withStyleFor: #temporaryVariable
			do: [aStream nextPutAll: name]