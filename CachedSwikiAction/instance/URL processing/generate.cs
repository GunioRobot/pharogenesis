generate
	1 to: (urlmap pages size) do: [:ref |
		self generate: (urlmap atID: ref) from: 'Beginning'.].
	self generateRecent.
