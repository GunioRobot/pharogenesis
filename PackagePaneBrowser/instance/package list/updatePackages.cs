updatePackages
	"Update the contents of the package list."

	editSelection := #none.
	self changed: #packageList.
	self changed: #package.
	self packageListIndex: 0 