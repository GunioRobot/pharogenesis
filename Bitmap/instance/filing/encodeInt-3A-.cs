encodeInt: int
	"Encode the integer int as per encodeInt:in:at:, and return it as a ByteArray"
	| byteArray next |
	byteArray _ ByteArray new: 5.
	next _ self encodeInt: int in: byteArray at: 1.
	^ byteArray copyFrom: 1 to: next - 1
