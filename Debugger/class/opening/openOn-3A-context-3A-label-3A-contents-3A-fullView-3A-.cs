openOn: process context: context label: title contents: contentsStringOrNil fullView: bool
	"Open a notifier in response to an error, halt, or notify. A notifier view just shows a short view of the sender stack and provides a menu that lets the user open a full debugger."

	| controller errorWasInUIProcess |
	Smalltalk isMorphic
		ifTrue: [errorWasInUIProcess _ CurrentProjectRefactoring newProcessIfUI: process]
		ifFalse: [controller _ ScheduledControllers activeControllerProcess == process
				ifTrue: [ScheduledControllers activeController]].
	[
		[	| debugger |
			debugger _ self new process: process controller: controller context: context.
			bool ifTrue: [debugger openFullNoSuspendLabel: title]
				ifFalse: [debugger openNotifierContents: contentsStringOrNil label: title].
			debugger errorWasInUIProcess: errorWasInUIProcess.
			Preferences logDebuggerStackToFile ifTrue: [
				Smalltalk logError: title inContext: context to: 'SqueakDebug.log'].
			Smalltalk isMorphic
				ifFalse: [ScheduledControllers searchForActiveController "needed since openNoTerminate (see debugger #open...) does not set up activeControllerProcess if activeProcess (this fork) is not the current activeControllerProcess (see #scheduled:from:)"].
		] on: Error do: [:ex |
			self primitiveError: 
				'Orginal error: ', 
				title asString, '.
	Debugger error: ', 
				([ex description] on: Error do: ['a ', ex class printString]), ':'
		]
	] fork.
	process suspend.
