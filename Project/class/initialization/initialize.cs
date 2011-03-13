initialize
	"This is the Top Project."   

	CurrentProject ifNil:
		[CurrentProject := super new initialProject.
		Project spawnNewProcessAndTerminateOld: true].

	"Project initialize"