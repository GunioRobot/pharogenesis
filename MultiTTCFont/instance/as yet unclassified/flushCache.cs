flushCache

	cache at: 1 put: ((1 to: 128) collect: [:i | Array with: -1 with: nil with: nil]).
