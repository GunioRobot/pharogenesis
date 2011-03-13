changeClass: class 
	"Include indication that a class definition has been changed. 
	 6/10/96 sw: don't accumulate this information for classes that don't want logging
	 7/12/96 sw: use wantsChangeSetLogging flag"

	class wantsChangeSetLogging
		ifTrue:
			[self atClass: class add: #change]