selectionPrintString
	| text nm |
	selectionUpdateTime _ [text _ [self selection printStringLimitedTo: 5000]
		on: Error do: 
		[nm _ self selectionIndex < 3
					ifTrue: ['self']
					ifFalse: [self selectedSlotName].
		text _ ('<error in printString: evaluate "' , nm , ' printString" to debug>') asText.
		text
			addAttribute: TextColor red
			from: 1
			to: text size.
		text]] timeToRun.
	^ text