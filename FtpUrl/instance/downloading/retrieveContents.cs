retrieveContents
	"currently assumes directories end in /, and things that don't end in / are files.  Also, doesn't handle errors real well...."
	| server contents pathString listing auth idx fileName serverName userName password |
	pathString _ self pathString.
	pathString _ pathString copyFrom: 2 to: pathString size. "remove the leading /"
	pathString last = $/ ifTrue:["directory?!"
		fileName _ nil.
	] ifFalse:[
		fileName _ pathString copyFrom: (pathString lastIndexOf: $/)+1 to: pathString size.
		pathString _ pathString copyFrom: 1 to: (pathString lastIndexOf: $/) - 1.
	].
	auth _ self authority.
	idx _ auth indexOf: $@.
	idx > 0 ifTrue:[
		serverName _ (auth copyFrom: idx+1 to: auth size).
		userName _ (auth copyFrom: 1 to: idx-1).
		password _ nil.
	] ifFalse:[
		serverName _ auth.
		userName _ 'anonymous'.
		password _ 'SqueakUser'.
	].
	server _ ServerDirectory servers 
		detect:[:s| s isTypeFTP and:[s server asLowercase = serverName asLowercase]]
		ifNone:[nil].
	server ifNil:[
		server _ ServerDirectory new.
		server server: serverName.
	] ifNotNil:[server _ server copy reset].
	server user: userName.
	password ifNotNil:[server password: password].
	server directory: pathString.

	fileName == nil ifFalse:[
		"a file"
		contents _ (server getFileNamed: fileName).
		server sleep.
		^MIMEDocument contentType: (MIMEDocument guessTypeFromName: self path last) content: contents].

	"a directory?"
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
	server sleep.
	^MIMEDocument contentType: 'text/html' content: listing