accountWithId: anIdString 
	"Look up an account. Return nil if missing.
	Raise error if it is not an account."

	| account |
	account := self objectWithId: anIdString.
	account ifNil: [^nil].
	account isAccount ifTrue:[^account].
	self error: 'UUID did not map to a account.'