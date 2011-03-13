initialize
	"WorldState initialize"

	MinCycleLapse _ 20.		"allows 50 frames per second..."
	DisableDeferredUpdates _ false.
	DeferredUIMessages _ SharedQueue new.