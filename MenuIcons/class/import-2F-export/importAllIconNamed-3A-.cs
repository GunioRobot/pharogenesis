importAllIconNamed: aString
	"self importIconNamed: 'Icons16:appearanceIcon'"

	
	| writer image stream |
	writer := GIFReadWriter on: (FileStream fileNamed: aString, '.gif').
	[ image := writer nextImage]	
		ensure: [writer close].
	stream := ReadWriteStream on: (String new).
	stream nextPutAll: aString ; cr.
	stream nextPutAll: (self methodStart: aString).
	image storeOn: stream.
	stream nextPutAll: self methodEnd.
	^ stream contents