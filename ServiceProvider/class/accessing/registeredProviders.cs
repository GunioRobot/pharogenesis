registeredProviders
	^ self allSubclasses collect: [:each | each new]