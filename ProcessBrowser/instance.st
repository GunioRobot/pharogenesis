Model
	subclass: #ProcessBrowser
	instanceVariableNames:
		'selectedProcess selectedContext methodText processList processListIndex stackList stackListIndex sourceMap selectedClass selectedSelector searchString autoUpdateProcess deferredMessageRecipient lastUpdate startedCPUWatcher'
	classVariableNames: 'Browsers SuspendedProcesses WellKnownProcesses'
	poolDictionaries: ''
	category: 'Tools-Process Browser'