retrieveContents
	| file pathString s type entries |
	pathString _ self pathForFile.
	file _ [FileStream readOnlyFileNamed: pathString] 
			on: FileDoesNotExistException do:[:ex| ex return: nil].
	file ifNotNil: [
		type _ file mimeTypes.
		type ifNotNil:[type _ type first].
		type ifNil:[MIMEDocument guessTypeFromName: self path last].
		^MIMELocalFileDocument 
			contentType: type
			contentStream: file].

	"see if it's a directory..."
	entries _ [(FileDirectory on: pathString) entries] 
				on: InvalidDirectoryError do:[:ex| ex return: nil].
	entries ifNil:[^nil].

	s _ WriteStream on: String new.
	(pathString endsWith: '/') ifFalse: [ pathString _ pathString, '/' ].
	s nextPutAll: '<title>Directory Listing for ', pathString, '</title>'.
	s nextPutAll: '<h1>Directory Listing for ', pathString, '</h1>'.
	s nextPutAll: '<ul>'.
	s cr.
	entries do: [ :entry |
		s nextPutAll: '<li><a href="'.
		s nextPutAll: entry name.
		s nextPutAll: '">'.
		s nextPutAll: entry name.
		s nextPutAll: '</a>'.
		s cr. ].
	s nextPutAll: '</ul>'.
	^MIMEDocument  contentType: 'text/html'  content: s contents  url: ('file://', pathString)