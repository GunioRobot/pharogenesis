changeSet: aChangeSet containsClass: aClass
	| theClass |
	theClass _ Smalltalk classNamed: aClass.
	theClass ifNil: [^ false].
	^ aChangeSet containsClass: theClass