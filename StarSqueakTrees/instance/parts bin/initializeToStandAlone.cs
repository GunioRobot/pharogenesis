initializeToStandAlone
	self initialize.
	treeTypeSelector := #tree2.
	self setup.  "Run earlier, but need to run again to get the #tree2 used"
	self startRunning