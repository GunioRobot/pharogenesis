resetNamespace
	"Reset the namespace used by the script editor"

	myScriptEditor setBindings: (myWonderland getNamespace).
	myActorViewer setSelectedActor: nil.

