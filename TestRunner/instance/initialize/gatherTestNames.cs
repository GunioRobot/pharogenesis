gatherTestNames

	| theNames |
	theNames _ (self testCases collect: [:each | each name]) asSortedCollection.
	theNames remove: #TestViaMethodCall ifAbsent: [^ theNames].
	Smalltalk at: #TestViaMethodCall ifPresent: [ :tvmc | tvmc addClassesTo: theNames ].
	^ theNames