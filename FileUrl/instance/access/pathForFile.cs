pathForFile
	"Path using local file system's delimiter.  $\ or $:"
	| first |
	^String streamContents: [ :s |
		first _ true.
		self path do: [ :p |
			first ifFalse: [ s nextPut: FileDirectory default pathNameDelimiter ].
			first _ false.
			s nextPutAll: p ] ]