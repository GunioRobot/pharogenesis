isCheckpointAvailable
	"Check that there is an 'sm' directory
	and that it contains at least one checkpoint."

	[^self lastCheckpointFilename notNil] on: Error do: [:ex | ^false]