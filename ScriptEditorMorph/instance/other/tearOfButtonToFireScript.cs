tearOfButtonToFireScript
	| aButton |
	aButton _ ScriptActivationButton new target: playerScripted.
	aButton actionSelector: #runScript:.
	aButton arguments: (Array with: scriptName).
	aButton establishLabelWording.
	self currentHand attachMorph: aButton