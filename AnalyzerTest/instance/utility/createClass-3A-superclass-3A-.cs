createClass: aClassname superclass: aClass 
	| r |
	r _ aClass
		subclass: aClassname
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Tests-KCP'.
	classesCreated add: r.
	^ r