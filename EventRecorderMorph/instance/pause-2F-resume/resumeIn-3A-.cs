resumeIn: aWorld
	"Resume playing or recording after a project switch."

	state = #suspendedPlay ifTrue:
		[self resumePlayIn: aWorld].
	state = #suspendedRecord ifTrue:
		[self resumeRecordIn: aWorld].
