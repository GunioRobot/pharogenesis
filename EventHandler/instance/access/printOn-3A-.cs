printOn: aStream
	| aVal recipients |
	super printOn: aStream.
	#('mouseDownSelector' 'mouseStillDownSelector' 'mouseUpSelector' 'mouseEnterSelector' 'mouseLeaveSelector' 'mouseEnterDraggingSelector' 'mouseLeaveDraggingSelector' 'doubleClickSelector' 'keyStrokeSelector') do:
		[:aName | (aVal _ self instVarNamed: aName) ~~ nil ifTrue:
			[aStream nextPutAll: '; ', aName, '=', aVal]].
	(recipients _ self allRecipients) size > 0 ifTrue:
		[aStream nextPutAll: ' recipients: '.
		recipients printOn: aStream]