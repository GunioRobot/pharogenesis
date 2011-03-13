fileOutClassModifications: class on: stream 
	"Write out class mod-- rename, comment, reorg, remove, on the given stream.  Differs from the superseded fileOutClassChanges:on: in that it does not deal with class definitions, and does not file out entire added classes.  5/15/96 sw"

	(self atClass: class includes: #rename) ifTrue:
		[stream nextChunkPut: (self oldNameFor: class), ' rename: #', class name; cr].

	(self atClass: class includes: #comment) ifTrue:
		[class organization putCommentOnFile: stream
			numbered: nil moveSource: false.
		stream cr].

	(self atClass: class includes: #reorganize) ifTrue:
		[class fileOutOrganizationOn: stream.
		stream cr]