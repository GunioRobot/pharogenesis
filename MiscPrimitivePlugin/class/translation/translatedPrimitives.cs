translatedPrimitives
	"an assorted list of various primitives"
	^#(
		(Bitmap compress:toByteArray:)
		(Bitmap decompress:fromByteArray:at:)
		(Bitmap encodeBytesOf:in:at:)
		(Bitmap encodeInt:in:at:)
		(String compare:with:collated:)
		(String translate:from:to:table:)	
		(String findFirstInString:inSet:startingAt:)
		(String indexOfAscii:inString:startingAt:)
		(String findSubstring:in:startingAt:matchTable:)
		(ByteArray hashBytes:startingWith:)
		(SampledSound convert8bitSignedFrom:to16Bit:)
	)
