isMorphic
	"Answer true if the user interface is running in Morphic rathern than 
	MVC.  By convention the gloabl variable World is set to nil when MVC is 
	running.  ScheduledControllers could be set to nil when Morphic is 
	running, but this symmetry is not yet in effect."

	^ World ~~ nil