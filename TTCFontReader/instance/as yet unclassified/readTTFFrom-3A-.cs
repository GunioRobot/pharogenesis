readTTFFrom: aStream

	"Read the raw font byte data"
	| fontData |
	(aStream respondsTo: #binary) ifTrue:[aStream binary].
	fontData _ aStream contents asByteArray.
	fontDescription _ TTCFontDescription new.

	^ self readFrom: fontData fromOffset: 0 at: EncodingTag.
