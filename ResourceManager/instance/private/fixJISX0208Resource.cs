fixJISX0208Resource

	| keys value url |
	keys _ resourceMap keys.

	keys do: [:key |
		value _ resourceMap at: key.
		url _ key urlString copy.
		url isOctetString not ifTrue: [url mutateJISX0208StringToUnicode].
		resourceMap removeKey: key.
		key urlString: url.
		resourceMap at: key put: value.
	].
