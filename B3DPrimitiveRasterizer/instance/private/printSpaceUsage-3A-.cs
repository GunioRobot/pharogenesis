printSpaceUsage: objects
	"Print out the maximum space used for processing the given objects"
	| spaceUsed |
	spaceUsed _ state spaceUsed.
	objects do:[:obj| spaceUsed _ spaceUsed + obj basicSize].
	spaceUsed _ spaceUsed * 4.
	Transcript cr; nextPutAll: spaceUsed asStringWithCommas; nextPutAll:' bytes max working set'; endEntry.