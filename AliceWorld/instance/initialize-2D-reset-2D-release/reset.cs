reset
	"Reset this Wonderland"

	"Initialize this Wonderland's shared namespace"
	myNamespace _ AliceNamespace new.

	"Reset the scheduler"
	myScheduler reset.

	"Reset the shared mesh and texture directories"
	sharedMeshDict _ Dictionary new.
	sharedTextureDict _ Dictionary new.

	"Reset the list of actor uniclasses"
	actorClassList do: [:aClass | aClass removeFromSystem ].
	actorClassList _ OrderedCollection new.

	"Rebuild the namespace"
	myNamespace at: 'scheduler' put: myScheduler.
	myNamespace at: 'world' put: self.

	"Create a new text output window"
	myTextOutputWindow setText: 'Reset'.

