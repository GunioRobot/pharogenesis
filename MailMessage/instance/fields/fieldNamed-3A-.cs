fieldNamed: aString
	"return the value of the field with the specified name.  If there is no such field, return an error"
	^self fieldNamed: aString ifAbsent: [
		self error: 'no such field: ', aString ].
