instantiatedUserScriptsDo: aBlock
	| aState |
	(aState _ self actorState) ifNotNil:
		[aState instantiatedUserScriptsDictionary do: aBlock]