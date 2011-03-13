fixJISX0208Resource

	| keys value url |
	keys := resourceMap keys.

	keys do: [:key |
		value := resourceMap at: key.
		url := key urlString copy.
		url isOctetString not ifTrue: [url mutateJISX0208StringToUnicode].
		resourceMap removeKey: key.
		key urlString: url.
		resourceMap at: key put: value.
	].
