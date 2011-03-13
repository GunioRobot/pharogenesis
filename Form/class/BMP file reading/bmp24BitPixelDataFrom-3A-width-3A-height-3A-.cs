bmp24BitPixelDataFrom: aBinaryStream width: w height: h
	"Read 24-bit pixel data from the given a BMP stream."

	| form rowBytes line blackPixelValue pixelLine pixIndex rgb |
	form _ Form extent: w@h depth: 32.
	rowBytes _ (((24 * w) + 31) // 32) * 4.
	line _ Form extent: w@1 depth: 32.
	blackPixelValue _ Color black pixelValueForDepth: 32.
	1 to: h do: [:i |
		pixelLine _ aBinaryStream next: rowBytes.
		pixIndex _ 1.
		1 to: w do: [:j |
			rgb _ (pixelLine at: pixIndex) +
				   ((pixelLine at: pixIndex + 1) bitShift: 8) +
				   ((pixelLine at: pixIndex + 2) bitShift: 16).
			"BMP's don't support transparency, so map zero pixels to black"
			rgb = 0 ifTrue: [rgb _ blackPixelValue].
			line bits at: j put: rgb.
			pixIndex _ pixIndex + 3].
		form copy: line boundingBox from: line to: 0@(h - i) rule: Form over].
	^ form
