readFrom: aStream

	"Read the raw font byte data"
	| fontData |
	(aStream respondsTo: #binary) ifTrue:[aStream binary].
	fontData _ aStream contents asByteArray.

	fonts _ self parseTTCHeaderFrom: fontData.
	^ ((Array with: fonts first) collect: [:offset |
		fontDescription _ TTCFontDescription new.
		self readFrom: fontData fromOffset: offset at: EncodingTag.
	]) at: 1.
