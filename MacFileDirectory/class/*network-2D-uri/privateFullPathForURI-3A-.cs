privateFullPathForURI: aURI
	| first path |

	path _ String streamContents: [ :s |
		first := false.
		aURI pathComponents do: [ :p |
			first ifTrue: [ s nextPut: self pathNameDelimiter ].
			first _ true.
			s nextPutAll: p ] ].
	^path unescapePercents
