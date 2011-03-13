fullPath: serverAndDirectory
	"Parse and save a full path"

	| start bare |
	bare _ serverAndDirectory.
	bare size > 7 ifTrue: [ 
		start _ (bare copyFrom: 1 to: 8) asLowercase.
		(start beginsWith: 'ftp://') 
			ifTrue: [type _ #ftp.
				bare _ bare copyFrom: 7 to: bare size].
		(start beginsWith: 'http://') 
			ifTrue: [type _ #http.
				bare _ bare copyFrom: 8 to: serverAndDirectory size]].
	server _ bare copyUpTo: self pathNameDelimiter.
	bare size > (server size +2) 
		ifTrue: [directory _ bare copyFrom: server size + 2 to: bare size]
		ifFalse: [directory _ ''].
