processDefineBitsLossless2: data
	| id format image |
	id := data nextWord.
	format := data nextByte.	
	format = 3 ifTrue:[image := self processAlphaColorMapData: data ]
				ifFalse:[image := self processAlphaBitmapData: data].	
	self recordBitmap: id data: image.
	
	^true