pathString
	"Path as it appears in a URL with $/ as delimiter."
	
	| first |
	^String streamContents: [ :s |
		"isAbsolute ifTrue:[ s nextPut: $/ ]."
		first := true.
		self path do: [ :p |
			first ifFalse: [ s nextPut: $/ ].
			first := false.
			s nextPutAll: p encodeForHTTP ] ]