fileOutPSFor: class on: stream 
	"Write out removals and initialization for this class."

	| dict changeType classRecord currentDef |
	classRecord _ changeRecords at: class name ifAbsent: [^ self].
	dict _ classRecord methodChangeTypes.
	dict keysSortedSafely do:
		[:key | changeType _ dict at: key.
		(#(remove addedThenRemoved) includes: changeType)
			ifTrue: [stream nextChunkPut: class name,
						' removeSelector: ', key storeString; cr]
			ifFalse: [(key = #initialize and: [class isMeta]) ifTrue:
						[stream nextChunkPut: class soleInstance name, ' initialize'; cr]]].
	((classRecord includesChangeType: #change)
		and: [(currentDef _ class definition) ~= (self fatDefForClass: class)]) ifTrue:
		[stream command: 'H3'; nextChunkPut: currentDef; cr; command: '/H3'].
	(classRecord includesChangeType: #reorganize) ifTrue:
		[class fileOutOrganizationOn: stream.
		stream cr]