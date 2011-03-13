initialize
	"Initialize the project, seting the CurrentProject as my parentProject and initializing my project preferences from those of the CurrentProject"

	super initialize.
	changeSet := ChangeSet new.
	transcript := TranscriptStream new.
	displayDepth := Display depth.
	parentProject := CurrentProject.
	isolatedHead := false.
	self initializeProjectPreferences
