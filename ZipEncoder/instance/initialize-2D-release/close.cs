close
	self flush.
	(encodedStream respondsTo: #close) ifTrue:[encodedStream close].