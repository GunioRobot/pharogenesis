finalSystemBuildingSteps
	"The final steps after all the file-ins, before we can call the system built.  1/18/96 sw"

	self reinitialize.
	self removeMacAppClassesFromSystem.
	Symbol rehash.     " Reclaim unused symbols"
	self showInTranscript: '** System Built **'.
	BuildingSystem _ false.