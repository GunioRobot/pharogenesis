sourcePixAtX: x y: y pixPerWord: srcPixPerWord
	| sourceWord index |
	self inline: true.
	(x < 0 or: [x >= srcWidth]) ifTrue: [^ 0].
	(y < 0 or: [y >= srcHeight]) ifTrue: [^ 0].
	index _ (y * sourcePitch) + ((x // srcPixPerWord) *4).
	sourceWord _ self srcLongAt: sourceBits + index.
	^ sourceWord >> ((32-sourcePixSize) - (x\\srcPixPerWord*sourcePixSize))