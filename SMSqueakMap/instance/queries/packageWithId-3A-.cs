packageWithId: anIdString 
	"Look up a package. Return nil if missing.
	Raise error if it is not a package."

	| package |
	package := self objectWithId: anIdString.
	package ifNil: [^nil].
	package isPackage ifTrue:[^package].
	self error: 'UUID did not map to a package.'