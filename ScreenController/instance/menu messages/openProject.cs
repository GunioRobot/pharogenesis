openProject 
	"Create and schedule a Project."

	| proj |
	Smalltalk at: #ProjectView ifPresent:
		[:c | proj _ Project new.
		c open: proj].
