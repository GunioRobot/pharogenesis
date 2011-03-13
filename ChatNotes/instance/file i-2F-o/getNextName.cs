getNextName
	"Return the next name available.
	All names are of the form '#.name' and '#.aiff'."
	| dir num |

	dir _ self audioDirectory.
	num _ 1.
	[dir fileExists: (num asString, '.name')] whileTrue: [num _ num + 1].
	^(num asString, '.')