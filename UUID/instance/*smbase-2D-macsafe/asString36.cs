asString36
	"Encode the UUID as a base 36 string using 0-9 and lowercase a-z.
	This is the shortest representation still being able to work as
	filenames etc since it does not depend on case nor characters
	that might cause problems."

	| candidate num |
	num _ 0.
	1 to: self size do: [:i | num _ num + ((256 raisedTo: i - 1) * (self at: i))].
	candidate _ num printStringBase: 36.
	^(candidate copyFrom: 4 to: candidate size) asLowercase