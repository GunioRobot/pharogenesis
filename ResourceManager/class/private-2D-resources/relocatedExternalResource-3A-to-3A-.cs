relocatedExternalResource: urlString to: newUrlString
	| originalURL |
	originalURL _ (self localizedExternalResources includesKey: urlString)
		ifTrue: [self localizedExternalResources at: urlString]
		ifFalse: [urlString].
	self localizedExternalResources at: newUrlString put: originalURL