setUp
	className := #TUTU.
	renamedName := #RenamedTUTU.
	self deleteClass.
	self deleteRenamedClass.
	Object subclass: className
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'KernelTests-Classes'