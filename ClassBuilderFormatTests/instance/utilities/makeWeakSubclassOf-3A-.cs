makeWeakSubclassOf: aClass
	subClass := aClass weakSubclass: self subClassName
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Kernel-Tests-ClassBuilder'