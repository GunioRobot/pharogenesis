initializeSetterFromEToySlotSpec: tuple
	"tuple holds an old etoy slot-item spec, of the form found in #additionsToViewerCategories methods.   Initialize the receiver to represent the getter of this item"

	selector _ tuple ninth.
	self
		wording: ('set ', tuple second);
		helpMessage: ('setter for', tuple third).
	receiverType _ #Player.
	argumentVariables _ Array with: (Variable new variableType: tuple fourth)
	