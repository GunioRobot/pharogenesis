initialize
	"Initialize the namespace"

	myDictionary _ AliceConstants copy.

	myWorkspace _ Workspace new.
	myWorkspace setBindings: myDictionary.
	myWorkspace embeddedInMorphicWindowLabeled: 'Namespace'.
