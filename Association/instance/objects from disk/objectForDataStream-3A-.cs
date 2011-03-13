objectForDataStream: refStrm
	| dp |
	"I am about to be written on an object file.  If I am a known global, write a proxy that will hook up with the same resource in the destination system."

	^ (Smalltalk associationAt: key ifAbsent: [nil]) == self 
		ifTrue: [dp _ DiskProxy global: #Smalltalk selector: #associationOrUndeclaredAt: 
							args: (Array with: key).
			refStrm replace: self with: dp.
			dp]
		ifFalse: [self]