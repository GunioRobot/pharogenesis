setup

	self clearAll.
	self createPatchVariable: #isUnburnt.
	self createPatchVariable: #flameLevel.
	self setupTrees.
	self setupFire.
	self setupBorder.
	worldDemons _ #(spreadFire consumeFuel).

