setup

	self clearAll.
	self createPatchVariable: #isUnburnt.
	self createPatchVariable: #flameLevel.
	self setupTrees.
	self setupFire.
	self setupBorder.
	worldDemons := #(spreadFire consumeFuel).

