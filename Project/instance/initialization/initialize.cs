initialize
	"Initialize the project, seting the CurrentProject as my parentProject and initializing my project preferences from those of the CurrentProject"

	changeSet _ ChangeSet new.
	transcript _ TranscriptStream new.
	displayDepth _ Display depth.
	parentProject _ CurrentProject.
	isolatedHead _ false.
	self initializeProjectPreferences
