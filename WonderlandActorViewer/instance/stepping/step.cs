step

	(updatingIsOn and: [ selectedActor notNil ] )
		ifTrue: [
				dataMorph setActor: selectedActor.
				thumbnailCamera setFocusObject: selectedActor.
				].

