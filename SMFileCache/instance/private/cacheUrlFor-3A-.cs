cacheUrlFor: aDownloadable
	"Find a cache URL for this downloadable.
	Returns nil if no server is available.
	Could use #relativeUrl also."

	| server |
	server := aDownloadable map class findServer.
	server ifNil: [^ nil].
	^'http://', server, '/object/', aDownloadable id asString, '/cache'