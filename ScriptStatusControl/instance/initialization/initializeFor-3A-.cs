initializeFor: aScriptInstantiation
	"Answer a control that will serve to reflect and allow the user to change the status of the receiver"

	|  statusReadout |
	self hResizing: #shrinkWrap.
	scriptInstantiation _ aScriptInstantiation.
	tickPauseButtonsShowing _ false.
	tickPauseWrapper _ AlignmentMorph newColumn beTransparent; yourself.
	self addMorphBack: tickPauseWrapper.
	self addMorphBack: (statusReadout _ UpdatingSimpleButtonMorph new).
	statusReadout setNameTo: 'trigger'.
	statusReadout target: aScriptInstantiation; wordingSelector: #status; actionSelector: #presentScriptStatusPopUp.
	statusReadout setBalloonText: 'when this script should run'.
	statusReadout actWhen: #buttonDown.

	self assurePauseTickControlsShow.
	aScriptInstantiation updateStatusMorph: self