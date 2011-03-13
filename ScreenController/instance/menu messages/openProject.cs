openProject 
	"Create and schedule a Project."

	| proj |
	Smalltalk at: #ProjectView ifPresent:
		[:c | proj := Project new.
		c open: proj].
