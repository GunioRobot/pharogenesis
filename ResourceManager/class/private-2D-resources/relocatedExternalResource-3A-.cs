relocatedExternalResource: urlString
	^self localizedExternalResources at: urlString ifAbsent: [nil]