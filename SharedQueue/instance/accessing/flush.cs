flush
	"Throw out all pending contents"
	accessProtect critical: [
		readPosition _ 1.
		writePosition _ 1.
		"Reset the read synchronization semaphore"
		readSynch initSignals].