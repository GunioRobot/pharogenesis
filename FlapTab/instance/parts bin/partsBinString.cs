partsBinString

	^ referent isPartsBin
		ifTrue:	['suspend parts-bin behavior']
		ifFalse:	['bestow parts-bin behavior']