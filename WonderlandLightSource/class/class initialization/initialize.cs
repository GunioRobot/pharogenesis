initialize
	"Add the light names to WonderlandConstants"

	WonderlandConstants at: 'ambient' put: 'ambientLight'.
	WonderlandConstants at: 'positional' put: 'positionalLight'.
	WonderlandConstants at: 'directional' put: 'directionalLight'.
	WonderlandConstants at: 'spotlight' put: 'spotLight'.
