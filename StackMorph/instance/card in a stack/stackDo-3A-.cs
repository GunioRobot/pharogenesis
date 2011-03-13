stackDo: aBlock
	"Evaluate aBlock on behalf of the receiver stack"

	^ aBlock value: self