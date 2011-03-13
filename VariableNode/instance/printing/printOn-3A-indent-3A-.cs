printOn: aStream indent: level 
	aStream withStyleFor: #variable
		do: [aStream nextPutAll: name].
