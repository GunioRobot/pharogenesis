dismissMorph: evt
	| w |
	w _ self world ifNil:[^self].
	w abandonAllHalos; stopStepping: self.
	self delete
