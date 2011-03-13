instantiatedUserScriptsDo: aBlock
	"Evaluate aBlock on behalf of all the instantiated user scripts in the receiver"

	| aState aCostume |
	((aCostume _ self costume) notNil and: [(aState _ aCostume actorStateOrNil) notNil]) ifTrue:
		[aState instantiatedUserScriptsDictionary do: aBlock]