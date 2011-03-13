statusColor
	result hasFailures 
		ifTrue:[ ^ Color yellow ].
	result hasErrors 
		ifTrue: [ ^ Color red ].
	^ Color green