serverForURL: aURLString
	| serversForURL server urlPath serverPath relPath |
	serversForURL _ self servers values select: [:each |
		(aURLString beginsWith: each downloadUrl)
		or: [(aURLString beginsWith: each realUrl)
		or: [aURLString , '/' beginsWith: each downloadUrl]]].
	serversForURL isEmpty
		ifTrue: [^nil].
	server _ serversForURL first.
	urlPath _ aURLString asUrl path.
	(urlPath isEmpty not
		and: [urlPath last isEmpty])
		ifTrue: [urlPath removeLast].
	serverPath _ server downloadUrl asUrl path.
	(serverPath isEmpty not
		and: [serverPath last isEmpty])
		ifTrue: [serverPath removeLast].
	urlPath size < serverPath size
		ifTrue: [^nil].
	relPath _ String new.
	serverPath size +1 to: urlPath size do: [:i | relPath _ relPath , '/' , (urlPath at: i)].
	^relPath isEmpty
		ifTrue: [server]
		ifFalse: [server directoryNamed: (relPath copyFrom: 2 to: relPath size)]