safeProjectName: aString

	self addProjectNameMorphFiller.
	self isTheRealProjectPresent ifFalse: [^ self].

	aString = project name ifFalse: [project changeSet name: aString].
	self setProperty: #SafeProjectName toValue: project name.
	self updateNamePosition.
	(owner isKindOf: SystemWindow) ifTrue: [owner setLabel: aString].