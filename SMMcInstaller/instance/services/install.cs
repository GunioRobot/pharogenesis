install
	"This service should bring the package to the client,
	unpack it if necessary and install it into the image.
	The package is notified of the installation."

	self cache; fileIn.
	packageRelease noteInstalled