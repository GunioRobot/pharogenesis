abandonUnnecessaryUniclasses
	"Player abandonUnnecessaryUniclasses"
	| oldCount oldFree newFree newCount report |
	oldCount _ self subclasses size - 1.
	oldFree _ Smalltalk garbageCollect.
	self allSubInstances do:
		[:aPlayer | aPlayer revertToUnscriptedPlayerIfAppropriate.  
		"encourage last one to get garbage-collected"
		aPlayer _ nil ].

	ScriptingSystem spaceReclaimed.
	newFree _ Smalltalk garbageCollect.
	newCount _ self subclasses size - 1.
	report _ 'Before: ', oldCount printString, ' uniclasses, ', oldFree
printString, ' bytes free
After:  ', newCount printString, ' uniclasses, ', newFree printString, '
bytes free'.
	Transcript cr; show: 'abandonUnnecessaryUniclasses:'; cr; show: report.
	^ report
	