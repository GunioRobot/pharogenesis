writeScanOn: strm
	"Two formats.  c125000255 or cblue;"

	| nn str |
	strm nextPut: $c.
	(nn _ color name) ifNotNil: [
		(self class respondsTo: nn) ifTrue: [
			^ strm nextPutAll: nn; nextPut: $;]].
	(Array with: color red with: color green with: color blue) do: [:float |
		str _ '000', (float * 255) asInteger printString.
		strm nextPutAll: (str copyFrom: str size-2 to: str size)]