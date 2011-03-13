fileOutOn: aFileStream moveSource: moveSource toFile: fileIndex initializing: aBool
	"File a description of the receiver on aFileStream. If the boolean argument,
	moveSource, is true, then set the trailing bytes to the position of aFileStream and
	to fileIndex in order to indicate where to find the source code."

	Transcript cr; show: name.
	super
		fileOutOn: aFileStream
		moveSource: moveSource
		toFile: fileIndex.
	self hasClassTrait ifTrue: [
		aFileStream cr; nextPutAll: '"-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- "!'; cr; cr.
		self classTrait
			fileOutOn: aFileStream
			moveSource: moveSource
			toFile: fileIndex]