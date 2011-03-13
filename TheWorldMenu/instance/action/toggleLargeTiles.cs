toggleLargeTiles
	"tall or small new tiles in scriptors"

	myProject projectParameterAt: #largeTiles put: 
		(myProject parameterAt: #largeTiles ifAbsent: [false]) not