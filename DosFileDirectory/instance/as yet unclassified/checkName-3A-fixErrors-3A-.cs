checkName: aFileName fixErrors: fixing
	"Check if the file name contains any invalid characters"
	| fName badChars hasBadChars |
	fName _ super checkName: aFileName fixErrors: fixing.
	badChars _ #( $: $< $> $| $/ $\ $? $* $") asSet.
	hasBadChars _ fName includesAnyOf: badChars.
	(hasBadChars and:[fixing not]) ifTrue:[^self error:'Invalid file name'].
	hasBadChars ifFalse:[^ fName].
	^ fName collect:
		[:char | (badChars includes: char) 
				ifTrue:[$#] 
				ifFalse:[char]]