reinstateDefaultFlaps
	"Utilities reinstateDefaultFlaps"
	self currentWorld deleteAllFlapArtifacts.
	self clobberFlapTabList.
	self initializeStandardFlaps.
	self currentWorld addGlobalFlaps.
