removeSelectorUnlogged: aSymbol 
	"Remove the message whose selector is aSymbol from the method dictionary of the receiver, if it is there. Answer nil otherwise.  Do not log the action either to the current change set or to the changes log"

	self deprecated: 'Use removeSelectorSilently: instead'.
	(self methodDict includesKey: aSymbol) ifFalse: [^ nil].
	SystemChangeNotifier uniqueInstance doSilently: [
		self organization removeElement: aSymbol].
	super removeSelector: aSymbol.