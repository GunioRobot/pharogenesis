actorList
	"Returns a list of actors in the scene"

	| scene |

	scene _ myWonderland getScene.

	^ { scene getName } , (scene appendChildrenNamesTo: '    ').
