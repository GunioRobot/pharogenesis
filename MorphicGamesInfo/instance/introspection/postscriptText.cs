postscriptText
	"Executed after load"
	^ 'Utilities informUser: ''Generating Games thumbnails in PartsBin, please wait...'' during: [
	PartsBin clearThumbnailCache.
	PartsBin cacheAllThumbnails.
].
"End ', self packageName, '"'