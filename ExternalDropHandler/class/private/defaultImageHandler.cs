defaultImageHandler
	| image sketch |
	^ExternalDropHandler
		type: 'image/'
		extension: nil
		action: [:stream :pasteUp :event |
			stream binary.
			image _ Form fromBinaryStream: ((RWBinaryOrTextStream with: stream contents) reset).
			Project current resourceManager 
				addResource: image 
				url: (FileDirectory urlForFileNamed: stream name) asString.
			sketch _ World drawingClass withForm: image.
			pasteUp addMorph: sketch centeredNear: event position] fixTemps