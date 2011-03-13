classes
	^ self classNames collect: [:ea | (environment at: ea) asNode]