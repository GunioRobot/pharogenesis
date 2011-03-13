browseSendersOf: aSelector name: labelString autoSelect: autoSelectString
	| title size senders |
	"Create and schedule a senders browser for aSelector."
	
	senders := self allCallsOn: aSelector.
	senders size = 0 ifTrue: 
		[^ self inform: 'There are no ' , labelString].

	title := (size := senders size) > 1
		ifFalse:	[labelString]
		ifTrue:	[labelString, ' [', size printString, ']'].

	ToolSet 
		browseSendersOf: aSelector
		name: title 
		autoSelect: autoSelectString