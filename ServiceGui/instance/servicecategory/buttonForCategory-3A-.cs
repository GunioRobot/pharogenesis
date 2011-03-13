buttonForCategory: aService 
	"see getstate for availability?"

	| aButton |
	aButton := PluggableButtonMorph 
				on: [:button | aService requestor: button requestor. 
								self class openMenuFor: aService] fixTemps
				getState: nil
				action: #value:.
	aButton arguments: (Array with: aButton).
	self styleButton: aButton.
	aButton
		label: aService buttonLabel.
	^aButton