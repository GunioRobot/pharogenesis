printOn: aStream indent: level 
	aStream withStyleFor: #variable
		do: [aStream nextPutAll: self name].
