removeClassFromSystem: aClass
	"Delete the class, aClass, from the system."

	aClass wantsChangeSetLogging ifTrue:
		[SystemChanges noteRemovalOf: aClass].
	aClass acceptsLoggingOfCompilation ifTrue:
		[Smalltalk logChange:  'Smalltalk removeClassNamed: #', aClass name].
	self removeClassFromSystemUnlogged: aClass
