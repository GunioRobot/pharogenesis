testLoadMissingNode
	| node |
	node := MCVersionInfo new.
	self assertMissing: node