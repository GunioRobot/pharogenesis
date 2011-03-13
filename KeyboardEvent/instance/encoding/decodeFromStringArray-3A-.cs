decodeFromStringArray: array
	"decode the receiver from an array of strings"
	type _ array first asSymbol.
	position _ CanvasDecoder decodePoint: (array at: 2).
	buttons _ CanvasDecoder decodeInteger: (array at: 3).
	keyValue _ CanvasDecoder decodeInteger: (array at: 4).
