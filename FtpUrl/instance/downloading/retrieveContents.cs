retrieveContents
	| server contents pathString listing |

	"currently assumes directories end in /, and things that don't end in / are files.  Also, doesn't handle errors real well...."

	server _ ServerDirectory new.
	server server: self authority.
	server directory: '/'.
	server user: 'anonymous'.
	server password: 'SqueakUser'.

	pathString _ self pathString.
	pathString _ pathString copyFrom: 2 to: pathString size. "remove the leading /"

	self path last size = 0 ifFalse: [
		"a file"
		contents _ (server getFileNamed: pathString).
		(contents respondsTo: #contents) ifTrue: [ 
			"the file exists--return it"
			^MIMEDocument contentType: (MIMEDocument guessTypeFromName: self path last) content: contents contents ]
		ifFalse: [
			"some error"
			^nil ]. ].

	"a directory?"
	server directory: self pathString.
	listing _ String streamContents: [ :stream |
		stream nextPutAll: '<title>', self pathString, '</title>'; cr.
		stream nextPutAll: '<h1>Listing for ', self pathString, '</h1>'; cr.
		stream nextPutAll: '<ul>'; cr.
		server entries do: [ :entry |
			stream nextPutAll: '<li>';
				nextPutAll: '<a href="', entry name encodeForHTTP.
			entry isDirectory ifTrue: [ stream nextPut: $/ ].
			stream nextPutAll: '">';
				nextPutAll: entry name;
				nextPutAll: '</a>';
				cr ] ].
	^MIMEDocument contentType: 'text/html' content: listing