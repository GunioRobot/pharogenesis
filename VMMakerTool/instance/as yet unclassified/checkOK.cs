checkOK
	"check as many settings as we can and report true if all seems ok"
	(platformPathMorph accept; hasUnacceptedEdits) ifTrue:[^false].
	(platformNameMorph accept; hasUnacceptedEdits) ifTrue:[^false].
	(generatedPathMorph accept; hasUnacceptedEdits) ifTrue:[^false].

	[vmMaker platformPluginsDirectory; crossPlatformPluginsDirectory]
		on: VMMakerException
		do: [:ex| self inform: ex messageText.
			^ false].
	^ true