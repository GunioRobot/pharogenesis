recordBitmapFill: index matrix: bmMatrix id: bitmapID clipped: aBoolean
	| fillStyle form |
	form := forms at: bitmapID ifAbsent:[^nil].
	fillStyle := BitmapFillStyle form: form.
	fillStyle origin: (bmMatrix localPointToGlobal: 0@0).
	fillStyle direction: (bmMatrix localPointToGlobal: form extent x @ 0) - fillStyle origin.
	fillStyle normal: (bmMatrix localPointToGlobal: 0 @ form extent y) - fillStyle origin.
	fillStyle tileFlag: aBoolean not.
	fillStyles at: index put: fillStyle.