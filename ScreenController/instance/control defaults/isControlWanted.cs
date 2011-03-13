isControlWanted

	^super isControlWanted and: [sensor anyButtonPressed]