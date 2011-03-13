embeddedResources
	"Return all embedded resources."
	
	^resources ifNil: [#()]
		ifNotNil: [resources select: [:r | r isEmbedded ]]
	