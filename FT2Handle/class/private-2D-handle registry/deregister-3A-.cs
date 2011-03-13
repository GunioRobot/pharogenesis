deregister: aHandle
	Registry ifNotNilDo: [ :reg | | finalizer |
		finalizer := reg remove: aHandle ifAbsent: [].
		finalizer ifNotNil: [ finalizer beNull ] ].
