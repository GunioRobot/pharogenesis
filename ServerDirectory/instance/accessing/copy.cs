copy

	| new |
	new := self clone.
	new urlObject: urlObject copy.
	^ new