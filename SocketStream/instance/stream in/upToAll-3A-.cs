upToAll: delims
	"Answer a subcollection from the current access position to the occurrence (if any, but not inclusive) of aCollection. If aCollection is not in the stream, answer the entire rest of the stream."
	"Optimized version using the positionOfSubCollection:. Based on a suggestion by miso"

	| searchBuffer index nextStartOfSearch currentContents |
	searchBuffer _ ReadWriteStream on: (String new: 1000).
	[nextStartOfSearch _ (searchBuffer position - delims size) max: 0.
	searchBuffer nextPutAll: self inStream upToEnd.
	self resetInStream.
	searchBuffer position: nextStartOfSearch.
	index _ searchBuffer positionOfSubCollection: delims.
	index = 0 and: [self atEnd not]]
		whileTrue: [self receiveData].

	currentContents := searchBuffer contents.
	^index = 0 
		ifTrue: [currentContents]
		ifFalse: [
			self pushBack: (currentContents copyFrom: index + delims size to: currentContents size).
			currentContents copyFrom: 1 to: (0 max: index-1)]