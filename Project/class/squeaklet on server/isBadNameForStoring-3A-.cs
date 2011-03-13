isBadNameForStoring: aString

	| badChars |

	"will the name of this project cause problems when stored on an arbitrary file system?"
	badChars _ #( $: $< $> $| $/ $\ $? $* $" $.) asSet.
	^aString size > 24 or: [
		aString anySatisfy: [ :each | 
			each asciiValue < 32 or: [badChars includes: each]
		]
	]
