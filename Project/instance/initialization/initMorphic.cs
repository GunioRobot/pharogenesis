initMorphic
	"Written so that Morphic can still be removed.  Note that #initialize is never actually called for a morphic project -- see the senders of this method."

	Smalltalk verifyMorphicAvailability ifFalse: [^ nil].
	changeSet := ChangeSet new.
	transcript := TranscriptStream new.
	displayDepth := Display depth.
	parentProject := CurrentProject.
	isolatedHead := false.
	world := PasteUpMorph newWorldForProject: self.
	Locale switchToID: CurrentProject localeID.
	self initializeProjectPreferences "Do this *after* a world is installed so that the project will be recognized as a morphic one."


