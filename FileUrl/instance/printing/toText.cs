toText
	| s |
	s _ WriteStream on: String new.
	s nextPutAll: self schemeName.
	s nextPut: $:.
	isAbsolute ifTrue:[ s nextPut: $/ ].	"the extra one"
	s nextPutAll: self pathString.
	fragment ifNotNil: [ s nextPut: $#.  s nextPutAll: fragment encodeForHTTP ].
	^s contents