buttonForAction: aService 
	"see getstate for availability?"

	| aButton |
	aButton := PluggableButtonMorph 
				on: aService
				getState: nil
				action: #execute.
	self styleButton: aButton.
	aButton
		label: aService buttonLabel;
		setBalloonText: aService description.
	^aButton