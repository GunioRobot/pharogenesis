selectAllUpgrades
	"select packages that appear to be upgrades of packages that are already installed"

	self allPossibleUpgrades 
		do: [:package | self planToInstallPackage: package]