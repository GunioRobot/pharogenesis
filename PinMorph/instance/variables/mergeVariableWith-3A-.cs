mergeVariableWith: otherPin
	"Change all pins with otherPin's selectors to these selectors,
	and then remove the slot and accessors for the old selectors"
	self removeModelVariable.
	self connectedPins do:
		[:connectee | connectee shareVariableOf: otherPin].
	self shareVariableOf: otherPin