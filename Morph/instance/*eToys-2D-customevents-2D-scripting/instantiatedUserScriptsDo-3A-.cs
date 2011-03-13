instantiatedUserScriptsDo: aBlock
	self actorStateOrNil ifNotNilDo: [ :aState | aState instantiatedUserScriptsDictionary do: aBlock]