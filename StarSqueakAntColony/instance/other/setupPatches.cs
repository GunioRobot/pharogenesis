setupPatches
	"Create patch variables for sensing the nest and food caches. The nestScent variable is diffused so that it forms a 'hill' of scent over the entire world with its peak at the center of the nest. That way, the ants always know which way the nest is."

	self createPatchVariable: 'food'.			"greater than zero if patch has food"
	self createPatchVariable: 'isNest'.		"greater than zero if patch is nest"
	self createPatchVariable: 'nestScent'.	"circular gradient with peak centered on nest"
	self createPatchVariable: 'pheromone'.	"dropped by ants when carrying food"
	self displayPatchVariable: 'pheromone'.
	self patchesDo: [:p |
		p color: self backgroundColor.
		self setupNest: p.
		self setupFood: p].

