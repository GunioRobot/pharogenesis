from: startIndex to: endIndex put: anObject
	"Put anObject in all indexes between startIndex 
	and endIndex. Very fast. Faster than to:do: for
	more than 26 positions. No range checks are 
	performed. Answer anObject."

	| written toWrite thisWrite |
	self at: startIndex put: anObject.
	written _ 1.
	toWrite _ endIndex - startIndex + 1.
	[written < toWrite] whileTrue:
		[thisWrite _ written min: toWrite - written.
		self 
			replaceFrom: startIndex + written
			to: startIndex + written + thisWrite - 1
			with: self startingAt: startIndex.
		written _ written + thisWrite].
	^ anObject