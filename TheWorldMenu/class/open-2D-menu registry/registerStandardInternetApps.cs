registerStandardInternetApps
	"Register the three currently-built-in internet apps and the hook for SqueakMap with the open-menu registry. This is a one-time initialization affair, contending with the fact that the three apps are already in the image."

	self registerOpenCommand: 
		{ 'Package Loader' . { TheWorldMenu . #openPackageLoader }. 'A tool that lets you browse and load packages from SqueakMap, an index of Squeak code available on the internet' }.

	#(Scamper Celeste IRCConnection) do:
		[:sym |
			(Smalltalk at: sym ifAbsent: [nil]) ifNotNilDo:
				[:aClass | aClass registerInOpenMenu]]

"
OpenMenuRegistry _ nil.
TheWorldMenu registerStandardInternetApps.
"