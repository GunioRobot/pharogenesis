removeClassFromSystem: aClass
	"Delete the class, aClass, from the system."

	SystemChanges noteRemovalOf: aClass.
	aClass acceptsLoggingOfCompilation ifTrue:
		[Smalltalk logChange:  'Smalltalk removeClassNamed: #', aClass name].
	SystemOrganization removeElement: aClass name.
	self removeKey: aClass name.
	self flushClassNameCache
