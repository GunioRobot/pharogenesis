nextInto: buffer 
	"fill buffer from my collection"
	(buffer isMemberOf: Bitmap) ifTrue:
		[1 to: buffer size do:
			[:index | buffer at: index put: (self nextNumber: 4)].
		^ buffer].
	1 to: buffer size do:
		[:index | buffer at: index put: self next].
	^ buffer