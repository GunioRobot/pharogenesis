retrieveContents
	| file pathString s dir |
	
	pathString _ self pathForFile.
	path last size > 0 ifTrue: [
		file _ FileStream oldFileOrNoneNamed: pathString.
		file ifNotNil: [ 
			^MIMEDocument contentType: (MIMEDocument guessTypeFromName: self path last) content: file contentsOfEntireFile ] ].

	"assume it's a directory..."
	s _ WriteStream on: String new.
	dir _ FileDirectory on: pathString.

	(pathString endsWith: '/') ifFalse: [ pathString _ pathString, '/' ].

	s nextPutAll: '<title>Directory Listing for ', pathString, '</title>'.
	s nextPutAll: '<h1>Directory Listing for ', pathString, '</h1>'.
	s nextPutAll: '<ul>'.
	s cr.
	dir entries do: [ :entry |
		s nextPutAll: '<li><a href="'.
		s nextPutAll: entry name.
		s nextPutAll: '">'.
		s nextPutAll: entry name.
		s nextPutAll: '</a>'.
		s cr. ].
	s nextPutAll: '</ul>'.

	^MIMEDocument  contentType: 'text/html'  content: s contents  url: ('file:', pathString)