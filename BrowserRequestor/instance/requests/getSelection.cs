getSelection
	self getBrowser selectedInterval ifEmpty: [^super getSelection].
	^ self getBrowser selectedInterval