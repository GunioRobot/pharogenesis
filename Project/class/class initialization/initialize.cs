initialize
	"This is the Top Project."   

	CurrentProject ifNil:
		[CurrentProject _ super new initialProject.
		CurrentProject spawnNewProcessAndTerminateOld: true].

	"Project initialize"