reclaimSpace
	"Reclaim space from the scripting system, and report the result in an informer"
	"ScriptingSystem reclaimSpace"

	| reclaimed |
	(reclaimed _ self spaceReclaimed)  > 0
		ifTrue:	[self inform: reclaimed printString, ' bytes reclaimed']
		ifFalse:	[self inform: 'Hmm...  Nothing gained this time.']