instantiatedUserScriptsDo: aBlock
	| aState |
	(aState _ self costume actorState) ifNotNil:
		[aState instantiatedUserScriptsDictionary do: aBlock]