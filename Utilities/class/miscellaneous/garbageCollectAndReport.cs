garbageCollectAndReport
	"Do a garbage collection, and report results to the user."

	| cc reportString |
	reportString _ String streamContents:
		[:aStream | 
			aStream nextPutAll: Smalltalk bytesLeftString.
			Smalltalk at: #Command ifPresent:
				[:cmdClass |
				(cc _ cmdClass instanceCount) > 0 ifTrue:
					[aStream cr; nextPutAll:
		('(note: there are ', cc printString,
		                         ' undo record(s) present in your
system; purging them may free up more space.)')]]].
			
	self inform: reportString
