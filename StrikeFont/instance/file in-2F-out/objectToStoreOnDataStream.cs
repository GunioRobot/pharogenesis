objectToStoreOnDataStream
	"I am about to be written on an object file.  Write a reference to a known Font in the other system instead.  "

	"A path to me"
	| known eval |
	thisContext sender receiver class == ReferenceStream ifTrue: [^ self].
		"special case for saving the default fonts on the disk.  See collectionFromFileNamed:"
	known _ TextStyle default fontArray detect: [:x | x name sameAs: self name] ifNone: [nil]. 
	known == self ifTrue: ["not modified"
		eval _ 'TextStyle default fontNamed: ', self name printString.
		^ DiskProxy global: #Compiler selector: #evaluate: 
			args: (Array with: eval)
			"We are expecting it to be there"].

	^ self	"Special font.  Write me out"
