printOn: aStream indent: level 
	"nb: this method is seemingly never reached"
	aStream withAttributes: (Preferences syntaxAttributesFor: #keyword)
		do: [aStream nextPutAll: key]