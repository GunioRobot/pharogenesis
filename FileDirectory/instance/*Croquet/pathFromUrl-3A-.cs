pathFromUrl: aFileUrl
	| first |
	^String streamContents: [ :s |
		first := false.
		aFileUrl path do: [ :p |
			first ifTrue: [ s nextPut: self pathNameDelimiter ].
			first _ true.
			s nextPutAll: p ] ].