showThumbnailString
	^( self hasProperty: #alwaysShowThumbnail)
		ifTrue:
			['stop showing thumbnails']
		ifFalse:
			['start showing thumbnails']
