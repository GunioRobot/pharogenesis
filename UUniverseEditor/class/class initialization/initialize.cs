initialize
	TheWorldMenu unregisterOpenCommand: 'Package Universe Editor'.

	TheWorldMenu registerOpenCommand: {'Universe Editor'. {self. #open}}.
	Preferences setWindowColorFor: self name to: (Color r: 0.194 g: 0.645 b: 1.0).