allDashes: aString
	"Answer true if the given string is not empty and consists entirely of dash characters."

	(aString isEmpty) ifTrue: [^false].
	aString detect: [: ch | ch ~= $-] ifNone: [^true].
	^false	"we must have detected a non-dash"