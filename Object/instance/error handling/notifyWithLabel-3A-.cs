notifyWithLabel: aString 
	"Create and schedule a Notifier with aString as the window label as well as the contents of the window, in  order to request confirmation before a process can proceed."

	Debugger
		openContext: thisContext
		label: aString
		contents: aString

	"nil notifyWithLabel: 'let us see if this works'"