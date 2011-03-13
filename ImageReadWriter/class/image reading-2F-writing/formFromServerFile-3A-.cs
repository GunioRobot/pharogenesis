formFromServerFile: fileName 
	"Answer a ColorForm stored on the file with the given name.  Meant to be called from during the getting of updates from the server.  That assures that (Utilities serverUrls) returns the right group of servers."
	| form urls doc |
	urls := Utilities serverUrls collect: [ :url | url , fileName ].	" fileName starts with: 'updates/'  "
	urls do: 
		[ :aURL | 
		(fileName findTokens: '.') last asLowercase = 'gif' ifTrue: 
			[ form := HTTPSocket httpGif: aURL.
			form = (ColorForm 
					extent: 20 @ 20
					depth: 8) ifTrue: [ self inform: 'The file ' , aURL , ' is ill formed.' ].
			^ form ].
		(fileName findTokens: '.') last asLowercase = 'bmp' ifTrue: 
			[ doc := HTTPSocket 
				httpGet: aURL
				accept: 'image/bmp'.
			form := Form fromBMPFile: doc.
			doc close.
			form 
				ifNil: 
					[ self inform: 'The file ' , aURL , ' is ill formed.'.
					^ Form new ]
				ifNotNil: [ ^ form ] ].
		self inform: 'File ' , fileName , 'does not end with .gif or .bmp' ].
	self inform: 'That file not found on any server we know'