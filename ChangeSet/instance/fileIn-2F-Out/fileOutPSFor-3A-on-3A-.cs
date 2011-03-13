fileOutPSFor: class on: stream 
	"Write out removals and initialization for this class."

	(methodChanges at: class name ifAbsent: [^ self]) associationsDo: [:mAssoc | 
		(#(remove addedThenRemoved) includes: mAssoc value)
			ifTrue:
				[stream nextChunkPut: class name,
					' removeSelector: ', mAssoc key storeString; cr]
			ifFalse:
				[(mAssoc key = #initialize and: [class isMeta]) ifTrue:
					[stream nextChunkPut: class soleInstance name, ' initialize'; cr]]]