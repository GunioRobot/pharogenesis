parse: request
	| filename |
	filename := (ServerAction serverDirectory) , ((request url) allButFirst copyReplaceAll: '/' with: 
		(ServerAction pathSeparator)).
	(filename endsWith: (ServerAction pathSeparator)) ifTrue: [filename _ filename , (ServerAction defaultFile)].
	^filename
