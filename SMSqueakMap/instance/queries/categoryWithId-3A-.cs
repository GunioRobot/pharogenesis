categoryWithId: anIdString 
	"Look up a category. Return nil if missing.
	Raise error if it is not a category."

	| cat |
	cat := self objectWithId: anIdString.
	cat ifNil: [^nil].
	cat isCategory ifTrue:[^cat].
	self error: 'UUID did not map to a category.'