readStamp
	"Get the time stamp of this method off the file"

	| item tokens anIndex |
	stamp _ ''.
	file ifNil: [^ stamp].
	file position: position.
	item _ file nextChunk.
	tokens _ Scanner new scanTokens: item.
	tokens size < 3 ifTrue: [^ stamp].
	anIndex _ tokens indexOf: #stamp: ifAbsent: [^ stamp].
	^ stamp _ tokens at: (anIndex + 1).
