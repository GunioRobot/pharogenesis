upgradeOldPackagesConfirmBlock: aBlock
	"First we find out which of the installed packages are upgradeable and old.
	Then we upgrade them if confirmation block yields true.
	The block will be called with each SMPackage to upgrade.
	We return a Dictionary with the packages we tried to upgrade as keys
	and the value being the result of the upgrade, true or false."

	| result |
	result := Dictionary new.
	self upgradeableAndOldPackages
		do: [:package |
			(aBlock value: package)
				ifTrue:[ result at: package put: package upgrade]].
	^result
