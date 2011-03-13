decodeImage: string
	| bitsStart depth width height bits rs numColors colorArray |

	bitsStart _ string indexOf: $|.
	bitsStart = 0 ifTrue: [^nil].
	rs := ReadStream on: string.
	rs peek == $C ifTrue: [
		rs next.
		numColors _ Integer readFromString: (rs upTo: $,).
		colorArray _ Array new: numColors.
		1 to: numColors do: [ :i |
			colorArray at: i put: (self decodeColor: (rs next: 12))
		].
	].
	depth := Integer readFromString: (rs upTo: $,).
	width :=  Integer readFromString: (rs upTo: $,).
	height :=  Integer readFromString: (rs upTo: $|).

	bits _ Bitmap newFromStream: (RWBinaryOrTextStream with: rs upToEnd) binary reset.

	colorArray ifNil: [
		^Form extent: width@height depth: depth bits: bits
	].
	^(ColorForm extent: width@height depth: depth bits: bits)
		colors: colorArray
