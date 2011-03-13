pathFromUrl: aFileUrl
	| first |
	^String streamContents: [ :s |
		first := false.
		aFileUrl path do: [ :p |
			first ifTrue: [ s nextPut: self pathNameDelimiter ].
			first := true.
			s nextPutAll: p ] ].