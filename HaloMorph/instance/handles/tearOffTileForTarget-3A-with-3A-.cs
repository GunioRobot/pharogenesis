tearOffTileForTarget: evt with: aHandle
	"Tear off a tile representing my inner target"

	self obtainHaloForEvent: evt andRemoveAllHandlesBut: nil.
	innerTarget tearOffTile