windowIsClosing
	super windowIsClosing.
	doneSemaphore ifNotNil: [ doneSemaphore signal ]