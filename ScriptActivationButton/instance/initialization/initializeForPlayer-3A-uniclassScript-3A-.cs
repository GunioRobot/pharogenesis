initializeForPlayer: aPlayer uniclassScript: aUniclassScript
	"Initialize the receiver for the given player and uniclass script"

	target _ aPlayer.
	uniclassScript _ aUniclassScript.
	actionSelector _ #runScript:.
	arguments _ Array with: uniclassScript selector.
	self establishLabelWording
	