cardWithNameBeginning: aString
	"Deprecated. Look up a package beginning with <aString>. Return nil if missing.
	We return the shortest matching one. We also strip out spaces and
	ignore case in both <aString> and the names."

	^self packageWithNameBeginning: aString