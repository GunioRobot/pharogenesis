storeSegment
	"Store my project out on the disk as an ImageSegment. Keep the
	outPointers in memory. Name it <project name>.seg. *** Caller must be
	holding (Project alInstances) to keep subprojects from going out. ***"
	| is sizeHint |
	World == world
		ifTrue: [^ false].
	"self inform: 'Can''t send the current world out'."
	world isInMemory
		ifFalse: [^ false].
	"already done"
	world
		ifNil: [^ false].
	world presenter
		ifNil: [^ false].
	World checkCurrentHandForObjectToPaste.
	sizeHint := self projectParameters
				at: #segmentSize
				ifAbsent: [0].
	is := ImageSegment new
				copyFromRootsLocalFileFor: (Array with: world presenter with: world)
				sizeHint: sizeHint.
	"world, and all Players"
	is state = #tooBig
		ifTrue: [^ false].
	is segment size < 2000
		ifTrue: ["debugging"
			Transcript show: self name , ' only ' , is segment size printString , 'bytes in Segment.';
				 cr].
	self projectParameters at: #segmentSize put: is segment size.
	is extract; writeToFile: self name.
	^ true