onDebug: process context: context title: title full: bool	
	
	| topCtxt |	
	
	topCtxt := process isActiveProcess ifTrue: [thisContext] ifFalse: [process suspendedContext].
	(topCtxt hasContext: context) ifFalse: [^ self error: 'context not in process'].	
	ToolSet debug: process context: context label: title contents: nil fullView: bool.