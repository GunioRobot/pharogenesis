readNativeResourceFrom: byteStream
	| img aStream |
	(byteStream isKindOf: FileStream) ifTrue:[
		"Ugly, but ImageReadWriter will send #reset which is implemented as #reopen and we may not be able to do so."
		aStream _ RWBinaryOrTextStream with: byteStream contents.
	] ifFalse:[
		aStream _ byteStream.
	].
	img _ [ImageReadWriter formFromStream: aStream] on: Error do:[:ex| nil].
	img ifNil:[^nil].
	(img isColorForm and:[self isColorForm]) ifTrue:[
		| cc |
		cc := img colors.
		img colors: nil.
		img displayOn: self.
		img colors: cc.
	] ifFalse:[
		img displayOn: self.
	].
	img _ nil.