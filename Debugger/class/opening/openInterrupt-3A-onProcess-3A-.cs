openInterrupt: aString onProcess: interruptedProcess
	"Open a notifier in response to an interrupt. An interrupt occurs when the user types the interrupt key (cmd-. on Macs, ctrl-c or alt-. on other systems) or when the low-space watcher detects that memory is low."

	| debugger |
	debugger _ self new.
	debugger
		process: interruptedProcess
		controller: (ScheduledControllers activeControllerProcess == interruptedProcess
						ifTrue: [ScheduledControllers activeController])
		context: interruptedProcess suspendedContext.
	debugger externalInterrupt: true.
	^ debugger
		openNotifierContents: debugger interruptedContext shortStack
		label: aString
