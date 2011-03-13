installPackages: wantedPackages
	"Given a Set of wanted SMPackages, create an installation task to compute
	possible installation scenarios.
	Returns an SMInstallationTask which can be further configured
	and then be sent #calculate after which it can be queried for results."
	
	^SMPackageInstallationTask engine: self wantedPackages: wantedPackages