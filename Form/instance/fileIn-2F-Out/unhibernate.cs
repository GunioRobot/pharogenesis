unhibernate
	"If my bitmap has been compressed into a ByteArray,
	then expand it now, and return true."
	| resBits |
	bits isForm ifTrue:[
		resBits _ bits.
		bits _ Bitmap new: self bitsSize.
		resBits displayResourceFormOn: self.
		^true].
	bits == nil ifTrue:[bits _ Bitmap new: self bitsSize. ^true].
	(bits isMemberOf: ByteArray)
		ifTrue: [bits _ Bitmap decompressFromByteArray: bits. ^ true].
	^ false