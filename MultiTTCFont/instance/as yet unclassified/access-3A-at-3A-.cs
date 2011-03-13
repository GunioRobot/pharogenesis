access: char at: index

	| wcache entry |
	wcache _ self cache.
	entry _ wcache at: index.
	wcache replaceFrom: index to: wcache size - 1 with: wcache startingAt: index + 1.
	wcache at: wcache size put: entry.
