isInstallable
	"Answer if any of my releases can be installed."

	^ releases anySatisfy: [:rel | rel isInstallable]