updateProcessList
	| oldSelectedProcess newIndex now |
	now _ Time millisecondClockValue.
	now - lastUpdate < 500
		ifTrue: [^ self].
	"Don't update too fast"
	lastUpdate _ now.
	oldSelectedProcess _ selectedProcess.
	processList _ selectedProcess _ selectedSelector _ nil.
	Smalltalk garbageCollectMost.
	"lose defunct processes"

	processList _ Process allSubInstances
				reject: [:each | each isTerminated].
	processList _ processList
				sortBy: [:a :b | a priority >= b priority].
	processList _ WeakArray withAll: processList.
	newIndex _ processList
				indexOf: oldSelectedProcess
				ifAbsent: [0].
	self changed: #processNameList.
	self processListIndex: newIndex