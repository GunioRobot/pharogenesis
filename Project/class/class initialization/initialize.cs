initialize
	"This is the Top Project."   

	CurrentProject ifNil:
		[CurrentProject _ super new initialProject.
		Project spawnNewProcessAndTerminateOld: true].

	"Project initialize"