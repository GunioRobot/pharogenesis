write4Bytes: bits 
	"Avoid overhead of large integers and nextWord:put:."
	| posBits bytes |
	bits >= 0
		ifTrue: [posBits _ bits]
		ifFalse: ["Change rep to twos complement."
				posBits _ 16rFFFFFFFF+(bits+1)].
	bytes _ ByteArray new: 4.
	bytes at: 1 put: (posBits digitAt: 4).
	bytes at: 2 put: (posBits digitAt: 3).
	bytes at: 3 put: (posBits digitAt: 2).
	bytes at: 4 put: (posBits digitAt: 1).
	file nextPutAll: bytes