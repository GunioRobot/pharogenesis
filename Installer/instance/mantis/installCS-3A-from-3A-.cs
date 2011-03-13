installCS: aFileName from: stream

	self ditchOldChangeSetFor: aFileName.
	self newChangeSetFromStream: stream named: (self validChangeSetName: aFileName).
