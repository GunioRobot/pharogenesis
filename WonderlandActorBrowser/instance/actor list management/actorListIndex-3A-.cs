actorListIndex: anInteger
	"Set the index of the currently selected actor."

	| scene childList |

	actorListIndex _ anInteger.
	myListMorph selectionIndex: anInteger.

	(anInteger = 0)
		ifTrue: [
					selectedActor _ nil.
				]
		ifFalse: [
					scene _ myWonderland getScene.
					childList _ scene getAllChildren.
					childList addFirst: scene.
					selectedActor _ childList at: anInteger.
				].

	actorViewer ifNotNil: [
		actorViewer setSelectedActor: selectedActor.
	].

	self contentsChanged.
