saveState
	"Save the current state in me prior to leaving this project"

	changeSet := ChangeSet current.
	thumbnail ifNotNil: [thumbnail hibernate].
	world := World.
	ActiveWorld := ActiveHand := ActiveEvent := nil.
	Sensor flushAllButDandDEvents. "Will be reinstalled by World>>install"
	transcript := Transcript.
