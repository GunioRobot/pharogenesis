eachStepInOwnerChainDo: aBlock
	"Perform aBlock for the receiver, its parent, etc., up the chain until nil reached"
	aBlock value: self.
	owner ifNotNil: [owner eachStepInOwnerChainDo: aBlock]