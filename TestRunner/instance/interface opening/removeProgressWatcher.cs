removeProgressWatcher
	progress ifNil: [ ^self ].
	progress delete.
	self dependents first updatePanesFromSubmorphs.
	progress _ nil
