objectStrmFromUpdates: fileName
	"Go to the known servers and look for this file in the updates folder.  It is an auxillery file, like .morph or a .gif.  Return a RWBinaryOrTextStream on it."

| urls doc |
Cursor wait showWhile: [
	urls _ (Smalltalk at: #EToySystem) serverUrls collect: [:url | url, 'updates/', fileName].
	urls do: [:aUrl |
		doc _ HTTPSocket httpGet: aUrl accept: 'application/octet-stream'.
		"test here for server being up"
		doc class == RWBinaryOrTextStream ifTrue: [^ doc reset]]].

PopUpMenu notify: 'All update servers are unavailable, or bad file name'.
^ nil