stepAt: millisecondClockValue
	"Step the receiver at the given point in time.  Send it to the model, the receiver is open and if it **has* a model"

	isCollapsed ifFalse: [model ifNotNil: [model stepAt: millisecondClockValue in: self]]