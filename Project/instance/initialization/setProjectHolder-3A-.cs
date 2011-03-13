setProjectHolder: aProject

	projectWindows _ ControlManager new.
	projectChangeSet _ ChangeSet new initialize.
	projectTranscript _ TextCollector new.
	displayDepth _ Display depth.
	projectHolder _ aProject