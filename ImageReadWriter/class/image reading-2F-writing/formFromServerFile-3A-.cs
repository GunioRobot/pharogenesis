formFromServerFile: fileName
	"Answer a ColorForm stored on the file with the given name."

	| form urls |
	urls _ (Smalltalk at: #EToySystem) serverUrls collect:
		[:url | url, fileName].  " fileName starts with: 'updates/'  "
	urls do: [:aURL |
		form _ HTTPSocket httpGif: aURL.
		form = (ColorForm extent: 20@20 depth: 8) ifFalse: [
			"a real answer" ^ form]].
	self inform: 'That file not found on any server we know'.