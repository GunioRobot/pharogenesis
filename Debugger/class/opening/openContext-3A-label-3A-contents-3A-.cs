openContext: aContext label: aString contents: contentsString
	| isolationHead |
	"Open a notifier in response to an error, halt, or notify. A notifier view just shows a short view of the sender stack and provides a menu that lets the user open a full debugger."
	<primitive: 19> "Simulation guard"
	ErrorRecursion not & Preferences logDebuggerStackToFile ifTrue:
		[Smalltalk logError: aString inContext: aContext to: 'SqueakDebug.log'].
	ErrorRecursion ifTrue:
		[ErrorRecursion _ false.
		(isolationHead _ Project current isolationHead)
			ifNil: [self primitiveError: aString]
			ifNotNil: [isolationHead revoke]].
	ErrorRecursion _ true.
	(Debugger context: aContext isolationHead: isolationHead)
		openNotifierContents: contentsString
		label: aString.
	ErrorRecursion _ false.
	Processor activeProcess suspend.
