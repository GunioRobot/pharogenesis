next: n into: buffer startingAt: startIndex
	"Read n objects into the given collection. 
	Return aCollection or a partial copy if less than
	n elements have been read."
	| c numRead count |
	numRead _ 0.
	["Force decompression if necessary"
	(c _ self next) == nil 
		ifTrue:[^buffer copyFrom: 1 to: startIndex+numRead-1].
	"Store the first value which provoked decompression"
	buffer at: startIndex + numRead put: c.
	numRead _ numRead + 1.
	"After collection has been filled copy as many objects as possible"
	count _ (readLimit - position) min: (n - numRead).
	buffer 
		replaceFrom: startIndex + numRead 
		to: startIndex + numRead + count - 1 
		with: collection 
		startingAt: position+1.
	position _ position + count.
	numRead _ numRead + count.
	numRead = n] whileFalse.
	^buffer