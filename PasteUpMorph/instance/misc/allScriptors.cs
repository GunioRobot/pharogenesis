allScriptors
	"Answer a list of all active scriptors running on behalf of the receiver.  This is a hook used in past demos and with a future life which however presently is vacuous"

	^ #()
"
	^ self allMorphs select: [:m | m isKindOf: Scriptor]"