step
	| doc |
	downloadQueue size > 0 ifTrue: [
		doc _ downloadQueue next.
		(doc notNil and: [doc mainType = 'image'])
		ifTrue: [
			[image _ ImageReadWriter  formFromStream: doc contentStream binary]
				ifError: [:err :rcvr | "ignore" image _ nil].
			self setContents ] ].