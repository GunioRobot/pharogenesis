chooseUpgrades
	"select packages that appear to be upgrades of packages that are already installed"
	self installSet selectAllUpgrades.
	
	self changed: #packageDescriptions.
	self changed: #rootCategoriesAndPackages.
