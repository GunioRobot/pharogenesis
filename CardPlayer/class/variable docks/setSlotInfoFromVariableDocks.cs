setSlotInfoFromVariableDocks
	"Get the slotInfo fixed up after a change in background shape.  Those instance variables that are proactively added by the user will persist, whereas those that are automatically generated will be updated"

	| aDock newInfo |
	
	self slotInfo copy do:  "Remove old automatically-created slots"
		[:aSlotInfo | (aDock _ aSlotInfo variableDock) ifNotNil:
			[slotInfo removeKey: aDock variableName]].

	self variableDocks do:  "Generate fresh slots from variable docks"
		[:dock |
			newInfo _ SlotInformation new type: dock variableType.
			newInfo variableDock: dock.
			slotInfo at: dock variableName asSymbol put: newInfo]