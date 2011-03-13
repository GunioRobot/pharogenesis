openContext: aContext label: aString contents: contentsString
	"Open a notifier in response to an error, halt, or notify. A notifier view just shows a short view of the sender stack and provides a menu that lets the user open a full debugger."

	ErrorRecursion ifTrue:
		[ErrorRecursion _ false.
		self primitiveError: aString].
	ErrorRecursion _ true.
	(Debugger context: aContext)
		openNotifierContents: contentsString
		label: aString.
	ErrorRecursion _ false.
	Processor activeProcess suspend.
