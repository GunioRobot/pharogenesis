objectStrmFromUpdates: fileName
	"Go to the known servers and look for this file in the updates folder.  It is an auxillery file, like .morph or a .gif.  Return a RWBinaryOrTextStream on it.    Meant to be called from during the getting of updates from the server.  That assures that (Utilities serverUrls) returns the right group of servers."

	| urls doc |
	Cursor wait showWhile:
		[urls _ Utilities serverUrls collect: [:url | url, 'updates/', fileName].
		urls do: [:aUrl |
			doc _ HTTPSocket httpGet: aUrl accept: 'application/octet-stream'.
			"test here for server being up"
			doc class == RWBinaryOrTextStream ifTrue: [^ doc reset]]].

	self inform: 'All update servers are unavailable, or bad file name'.
	^ nil