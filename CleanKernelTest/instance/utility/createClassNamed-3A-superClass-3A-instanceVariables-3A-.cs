createClassNamed: aClassname superClass: aClass instanceVariables: instvarString

	| r |
	r := aClass
		subclass: aClassname
		instanceVariableNames: instvarString
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Tests-KCP'.
	self classesCreated add: r.
	^ r