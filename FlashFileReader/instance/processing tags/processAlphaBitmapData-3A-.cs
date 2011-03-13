processAlphaBitmapData: data

	" read zlib compressed alphabitmapdata from data stream"

	| zLibStream width height r g b a image |

	"read width and height of image"
	width := data nextWord.
	height := data nextWord.
	"self halt."	

	zLibStream := ZLibReadStream on: data stream contents from: data position + 1  to: data size.
	image := Form extent: (width @ height) depth: 32.
	
	1 to: image bits size do:[:i|
		a := zLibStream next.
		r := zLibStream next.
		g := zLibStream next.
		b := zLibStream next.
		a = 0 ifTrue:[ image bits at: i put: 0]
					ifFalse:[image bits at: i put: ( a << 24 ) + ( r << 16) + ( g << 8) + b]
	].
	
	^ image

	
	

	

	
	
	