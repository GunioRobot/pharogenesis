makeVariableSubclassOf: aClass
	subClass := aClass variableSubclass: self subClassName
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Kernel-Tests-ClassBuilder'.