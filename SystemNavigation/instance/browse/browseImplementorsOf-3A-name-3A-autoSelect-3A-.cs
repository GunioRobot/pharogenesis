browseImplementorsOf: aSelector name: labelString autoSelect: autoSelectString
	"Create and schedule a senders browser for aSelector."	
	| implementors title size |
	
	implementors := self allImplementorsOf: aSelector.
	implementors size = 0 ifTrue: 
		[^ self inform: 'There are no ' , labelString].
	
	title := (size := implementors size) > 1
		ifFalse:	[labelString]
		ifTrue:	[ labelString, ' [', size printString, ']'].
	
	ToolSet 
		browseImplementorsOf: aSelector
		name: title
		autoSelect: autoSelectString