tool: actionButton action: aSelector cursor: aCursor evt: evt
	"Set the current tool and action for the paintBox.  "

	tool ifNotNil: [
		tool == actionButton ifFalse: [
			tool state: #off.
			action == #stamp: ifTrue: [self stampDeEmphasize]]].
	tool _ actionButton.		"A ThreePhaseButtonMorph"
	"tool state: #on.	already done"
	action _ aSelector.		"paint:"
	currentCursor _ aCursor.
	self notifyWeakDependentsWith: {#action. evt. action}.
	self notifyWeakDependentsWith: {#currentCursor. evt. currentCursor}.
