addProgressObserver: anObserver
	"progress will be sent to anObserver.  anObserver should respond to show:, endEntry, cr....  Transcript things"
	progressObservers add: anObserver