initialize

	changeSet _ ChangeSet new initialize.
	transcript _ TranscriptStream new.
	displayDepth _ Display depth.
	parentProject _ CurrentProject.
	isolatedHead _ false.
