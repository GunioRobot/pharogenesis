registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(JoystickMorph		authoringPrototype		'Joystick'	'A joystick-like control') 
						forFlapNamed: 'PlugIn Supplies'.
						cl registerQuad: #(JoystickMorph		authoringPrototype		'Joystick'	'A joystick-like control') 
						forFlapNamed: 'Scripting'.
						cl registerQuad: #(JoystickMorph		authoringPrototype		'Joystick'	'A joystick-like control') 
						forFlapNamed: 'Supplies']