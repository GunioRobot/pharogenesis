readImage
	| width height nComponents pixels size |
	width := self readInt32.
	self skipSeparators.
	height := self readInt32.
	size := width * height.
	self skipSeparators.
	nComponents := self readInt32.
	self skipSeparators.
	nComponents <= 4 ifTrue:[
		pixels := Bitmap new: size.
	] ifFalse:[
		pixels := Array new: size.
	].
	1 to: size do:[:i|
		self skipSeparators.
		pixels at: i put: self readInt32.
	].
	^Array with: width with: height with: nComponents with: pixels.