printOnStream: aStream

	home == nil ifTrue: [^aStream print: 'a BlockContext with home=nil'].
	aStream print: '[] in '.
	super printOnStream: aStream