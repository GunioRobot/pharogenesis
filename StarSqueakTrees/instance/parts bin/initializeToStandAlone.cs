initializeToStandAlone
	self initialize.
	treeTypeSelector _ #tree2.
	self setup.  "Run earlier, but need to run again to get the #tree2 used"
	self startRunning