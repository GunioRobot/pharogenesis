cCodeForMiscPrimitives
	"Return the contents of the miscellaneous primitives file, which is generated via automatic translation to C."

	^ CCodeGenerator new codeStringForPrimitives: #(
		(Bitmap compress:toByteArray:)
		(Bitmap decompress:fromByteArray:at:)
		(Bitmap encodeBytesOf:in:at:)
		(Bitmap encodeInt:in:at:)
		(String compare:with:collated:)
		(String translate:from:to:table:)	
		(String findFirstInString:inSet:startingAt:)
		(String indexOfAscii:inString:startingAt:)
		(String findSubstring:in:startingAt:matchTable:)
		(SampledSound convert8bitSignedFrom:to16Bit:))
