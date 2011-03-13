handlesFileEnding: ending
	ending = 'mcz' ifTrue: [ ^true ].
	(ending = 'mcm' and: [ self isMCMReaderAvailable ]) ifTrue: [ ^true ].
	^false