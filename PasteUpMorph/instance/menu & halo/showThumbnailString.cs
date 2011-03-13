showThumbnailString
	"Answer the string to be shown in a menu to represent the show-thumbnails status"

	^( self hasProperty: #alwaysShowThumbnail)
		ifTrue:
			['<on>show thumbnails']
		ifFalse:
			['<off>show thumbnails']
