fileNamesMatching: pat
	"
	FileDirectory default fileNamesMatching: '*'
	FileDirectory default fileNamesMatching: '*.image;*.changes'
	"
	
	| files |
	files _ OrderedCollection new.
	
	(pat findTokens: ';', String crlf) do: [ :tok | 
		files addAll: (self fileNames select: [:name | tok match: name]) ].
	
	^files
