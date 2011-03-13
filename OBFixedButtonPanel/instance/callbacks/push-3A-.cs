push: aModel
	(actions at: aModel) ifNotNilDo: [:action | action trigger]