primBitmapdecompressfromByteArrayat
	| indexInt index baOop bmOop baSize bmSize ba bm |
	indexInt _ self stackTop.
	(self isIntegerValue: indexInt) ifFalse: [^ self primitiveFail].
	index _ self integerValueOf: indexInt.
	baOop _ self stackValue: 1.
	bmOop _ self stackValue: 2.
	baSize _ self stSizeOf: baOop.
	bmSize _ self stSizeOf: bmOop.
	ba _ ByteArray new: baSize.
	bm _ Bitmap new: bmSize.

	"Copy the byteArray into ba"
	1 to: baSize do: [:i | ba at: i put: (self fetchByte: i-1 ofObject: baOop)].

	"Decompress ba into bm"
	bm decompress: bm fromByteArray: ba at: index.

	"Then copy bm into the Bitmap"
	1 to: bmSize do: [:i | self storeWord: i-1 ofObject: bmOop withValue: (bm at: i)].
	self pop: 3