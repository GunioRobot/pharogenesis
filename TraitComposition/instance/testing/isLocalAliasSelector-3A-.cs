isLocalAliasSelector: aSymbol
	"Return true if the selector aSymbol is an alias defined
	in this composition."

	| methodDescription |
	methodDescription _ (self methodDescriptionsForSelector: aSymbol)
		detect: [:each | each selector = aSymbol].
	^methodDescription isLocalAliasSelector