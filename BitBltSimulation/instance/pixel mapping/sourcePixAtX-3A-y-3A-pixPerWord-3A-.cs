sourcePixAtX: x y: y pixPerWord: srcPixPerWord
	| sourceWord index |
	self inline: true.
	(x < 0 or: [x >= srcWidth]) ifTrue: [^ 0].
	(y < 0 or: [y >= srcHeight]) ifTrue: [^ 0].
	index _ (y * sourceRaster + (x // srcPixPerWord) *4).
												"4 = BaseHeaderSize"
	sourceWord _ interpreterProxy longAt: sourceBits + 4 + index.
	^ sourceWord >> ((32-sourcePixSize) - (x\\srcPixPerWord*sourcePixSize))