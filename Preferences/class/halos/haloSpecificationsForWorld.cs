haloSpecificationsForWorld
	| desired |
	"Answer a list of HaloSpecs that describe which halos are to be used on a world halo, what they should look like, and where they should be situated"
	"Preferences resetHaloSpecifications"

	desired _ #(addDebugHandle: addMenuHandle: addTileHandle: addViewHandle: addHelpHandle: addScriptHandle: addPaintBgdHandle:).
	^ self haloSpecifications select:
		[:spec | desired includes: spec addHandleSelector]