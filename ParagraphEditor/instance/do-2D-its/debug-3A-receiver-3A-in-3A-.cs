debug: aCompiledMethod receiver: anObject in: evalContext

	| selector guineaPig debugger context |
	selector _ evalContext isNil ifTrue: [#DoIt] ifFalse: [#DoItIn:].
	anObject class addSelectorSilently: selector withMethod: aCompiledMethod.
	guineaPig _ evalContext isNil
		ifTrue: [[anObject DoIt] newProcess]
		ifFalse: [[anObject DoItIn: evalContext] newProcess].
	context _ guineaPig suspendedContext.
	debugger _ Debugger new
		process: guineaPig
		controller: ((Smalltalk isMorphic not and: [ScheduledControllers inActiveControllerProcess])
				ifTrue: [ScheduledControllers activeController]
				ifFalse: [nil])
		context: context
		isolationHead: nil.
	debugger openFullNoSuspendLabel: 'Debug it'.
	[debugger interruptedContext method == aCompiledMethod]
		whileFalse: [debugger send].
	anObject class basicRemoveSelector: selector