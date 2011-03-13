filterViewerCategoryDictionary: dict
	"dict has keys of categories and values of priority.
	You can re-order or remove categories here."

	self wantsConnectionVocabulary
		ifFalse: [ dict removeKey: #'connections to me' ifAbsent: [].
			dict removeKey: #connection ifAbsent: []].
	self wantsConnectorVocabulary
		ifFalse: [ dict removeKey: #connector ifAbsent: [] ].
	self wantsEmbeddingsVocabulary
		ifFalse: [dict removeKey: #embeddings ifAbsent: []].
	Preferences eToyFriendly
		ifTrue:
			[dict removeKey: #layout ifAbsent: []].
	(Preferences eToyFriendly or: [self isWorldMorph not]) ifTrue:
		[dict removeKey: #preferences ifAbsent: []].