openProject 
	"Create and schedule a Project."
	| proj |
	Smalltalk at: #ProjectView ifPresent:
		[:c | proj _ Project new.
		proj projectParameters at: #globalFlapsEnabledInProject put: false.
		c open: proj].
