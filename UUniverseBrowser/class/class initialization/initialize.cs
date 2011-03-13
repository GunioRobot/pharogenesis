initialize
	#('Package Browser (basic)' 'Universe Browser') do: [:oldName |
		TheWorldMenu unregisterOpenCommand: oldName ].
	
	TheWorldMenu registerOpenCommand: {'Universe Browser (basic)'. {self. #open}}.
	Preferences setWindowColorFor: self name to: (Color r: 0.194 g: 0.645 b: 1.0).