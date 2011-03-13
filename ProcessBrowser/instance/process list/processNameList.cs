processNameList
	"since processList is a WeakArray, we have to strengthen the result"
	^ processList asOrderedCollection
		collect: [:each | self prettyNameForProcess: each] 