processAlphaColorMapData: data

	" read zlib compressed alphacolormapdata from data stream"
	| zLibStream width height colorTableSize colorTable r g b a image color |
	"read width and height of image"
	width := data nextWord.
	height := data nextWord.
	colorTableSize := data nextByte.

	zLibStream := ZLibReadStream on: data stream contents from: data position + 1  to: data size.
	
	"read color table"
	colorTable := Array new: colorTableSize + 1.
	1 to: colorTableSize + 1 do:[ :i|
		r := zLibStream next.
		g := zLibStream next.
		b := zLibStream next.
		a := zLibStream next.
		colorTable at: i put: ( a << 24 ) + ( r << 16) + ( g << 8) + b.
	].

	"round width to 32 bit allignment"
	(width \\ 32) > 0 ifTrue:[ width := 32 * (( width // 32 ) + 1)].

	image := Form extent: (width @ height) depth: 32.

	1 to: image bits size do:[:i|
		color := colorTable at: zLibStream next.
		(color >> 24) = 0 ifTrue:[ image bits at: i put: 0]
					ifFalse:[image bits at: i put: color]
	].
	^ image

	
	