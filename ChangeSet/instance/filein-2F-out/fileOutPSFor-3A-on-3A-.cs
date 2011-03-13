fileOutPSFor: class on: stream 
	"Write out removals and initialization for this class."

	| dict changeType classRecord currentDef |
	classRecord := changeRecords at: class name ifAbsent: [^ self].
	dict := classRecord methodChangeTypes.
	dict keysSortedSafely do:
		[:key | changeType := dict at: key.
		(#(remove addedThenRemoved) includes: changeType)
			ifTrue: [stream nextChunkPut: class name,
						' removeSelector: ', key storeString; cr]
			ifFalse: [(key = #initialize and: [class isMeta]) ifTrue:
						[stream nextChunkPut: class soleInstance name, ' initialize'; cr]]].
	((classRecord includesChangeType: #change)
		and: [(currentDef := class definition) ~= (self fatDefForClass: class)]) ifTrue:
		[stream nextChunkPut: currentDef; cr ].
	(classRecord includesChangeType: #reorganize) ifTrue:
		[class fileOutOrganizationOn: stream.
		stream cr]