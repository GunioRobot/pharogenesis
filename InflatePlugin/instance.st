InterpreterPlugin
	subclass: #InflatePlugin
	instanceVariableNames:
		'zipCollection zipReadLimit zipPosition zipState zipBitBuf zipBitPos zipSource zipSourcePos zipSourceLimit zipLitTable zipDistTable zipCollectionSize zipLitTableSize zipDistTableSize '
	classVariableNames: 'MaxBits StateNoMoreData '
	poolDictionaries: ''
	category: 'VMConstruction-Plugins'