dismissMorph
	"This is called from an explicit halo destroy/delete action."

	| w |
	w _ self world ifNil:[^self].
	w abandonAllHalos; stopStepping: self.
	self delete