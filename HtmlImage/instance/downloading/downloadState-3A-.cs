downloadState: baseUrl 
	|  sourceUrl imageSource |

	image ifNil: [ 
		sourceUrl _ self src.
		sourceUrl ifNotNil: [ 
			imageSource _ HTTPSocket httpGetDocument: (sourceUrl asUrlRelativeTo: baseUrl asUrl) toText.
			imageSource contentType = 'image/gif'  ifTrue: [
				[image _ (GIFReadWriter on: (RWBinaryOrTextStream with: imageSource content) reset binary) nextImage ]
				ifError: [ :a :b |  "could not decode--ignore it"  image _ nil ] ].
			 ] ].
