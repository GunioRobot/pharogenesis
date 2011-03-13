statusColor
	result hasPassed 
		ifTrue:[ ^ Color green ].
	result hasErrors 
		ifTrue: [ ^ Color red ].
	^ Color yellow.