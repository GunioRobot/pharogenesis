storeSegment
	"Store my project out on the disk as an ImageSegment.  Keep the outPointers in memory.  Name it <project name>.seg.  *** Caller must be holding (Project alInstances) to keep subprojects from going out. ***"

| is response sizeHint |
world == World ifTrue: [^ false]. 
	"self inform: 'Can''t send the current world out'."
world isInMemory ifFalse: [^ false].  "already done"
world isMorph ifFalse: [
	self projectParameters at: #isMVC put: true.
	^ false].	"Only Morphic projects for now"
world ifNil: [^ false].  world presenter ifNil: [^ false].

Utilities emptyScrapsBook.
World currentHand objectToPaste ifNotNil: [
	response _ (PopUpMenu labels: 'Delete\Keep' withCRs)
		startUpWithCaption: 'Hand is holding a Morph in its paste buffer:\' withCRs,
			World currentHand objectToPaste printString.
	response = 1 ifTrue: [World currentHand clearPasteBuffer]].
world releaseSqueakPages.
sizeHint _ self projectParameters at: #segmentSize ifAbsent: [0].

is _ ImageSegment new copyFromRootsLocalFileFor: 
			(Array with: world presenter with: world)	"world, and all Players"
		 sizeHint: sizeHint.

is state = #tooBig ifTrue: [^ false].
is segment size < 2000 ifTrue: ["debugging" 
	Transcript show: self name, ' only ', is segment size printString, 
		'bytes in Segment.'; cr].
self projectParameters at: #segmentSize put: is segment size.
is extract; writeToFile: self name.
^ true
