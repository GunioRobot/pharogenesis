debugWithTitle: title
	"Open debugger on self"

	| context |
	context _ self isActiveProcess ifTrue: [thisContext] ifFalse: [self suspendedContext].
	self debug: context title: title full: true.
