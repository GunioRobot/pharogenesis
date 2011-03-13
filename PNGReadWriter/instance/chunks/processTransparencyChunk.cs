processTransparencyChunk

	| red green blue |

	"Transcript show: '  TRANSPARENCY ',chunk printString."
	colorType = 0 ifTrue: [
		transparentPixelValue _ chunk unsignedShortAt: 1 bigEndian: true.
		^self
	].
	colorType = 2 ifTrue: [
		red _ chunk at: 2.
		green _ chunk at: 2.
		blue _ chunk at: 2.
		transparentPixelValue _ 16rFF00 + red << 8 + green << 8 + blue.
		^self
	].
	colorType = 3 ifTrue: [
		chunk withIndexDo: [ :alpha :index |
			palette at: index put: ((palette at: index) alpha: alpha/255)
		].
		^self
	].
