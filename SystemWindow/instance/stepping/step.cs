step
	"Step the receiver.  Send it to the model, the receiver is open and if it **has* a model"

	isCollapsed ifFalse: [model ifNotNil: [model stepIn: self]]