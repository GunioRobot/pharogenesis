nextBits: n put: anInteger
	"Write the next n bits to my bit stream."

	| buf bufBits bitsAvailable shift |
	self inline: true.

	buf _ anInteger.
	bufBits _ n.
	[true] whileTrue: [
		bitsAvailable _ 8 - bitPosition.
		shift _ bitsAvailable - bufBits.  "either left or right shift"
		"append high bits of buf to end of currentByte:"
		currentByte _ currentByte + (buf bitShift: shift).
		shift < 0
			ifTrue: [  "currentByte buffer filled; output it"
				encodedBytes at: (byteIndex _ byteIndex + 1) put: currentByte.
				bitPosition _ 0.
				currentByte _ 0.
				"clear saved high bits of buf:"
				buf _ buf bitAnd: (1 bitShift: 0 - shift) - 1.
				bufBits _ bufBits - bitsAvailable]
			ifFalse: [  "still some bits available in currentByte buffer"
				bitPosition _ bitPosition + bufBits.
				^ self]].
