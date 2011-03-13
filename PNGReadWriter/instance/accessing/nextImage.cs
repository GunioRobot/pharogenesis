nextImage

	filtersSeen _ Bag new.
	globalDataChunk _ nil.
	transparentPixelValue _ nil.
	unknownChunks _ Set new.
	stream reset.
	(stream respondsTo: #binary) ifTrue: [ stream binary] .
	stream skip: 8.
	[stream atEnd] whileFalse: [
		self processNextChunk.
	].
	chunk _ globalDataChunk.
	chunk ifNotNil: [self processIDATChunk].
	unknownChunks isEmpty ifFalse: [
		"Transcript show: ' ',unknownChunks asSortedCollection asArray printString."
	].
	self debugging ifTrue: [
		Transcript cr; show: 'form = ',form printString.
		Transcript cr; show: 'colorType = ',colorType printString.
		Transcript cr; show: 'interlaceMethod = ',interlaceMethod printString.
		Transcript cr; show: 'filters = ',filtersSeen sortedCounts asArray printString.
	].
	^ form
