install
	"This service should bring the package release to the client,
	unpack it if necessary and install it into the image.
	The package release should be notified of the installation using
	'packageRelease noteInstalled'."

	self subclassResponsibility 