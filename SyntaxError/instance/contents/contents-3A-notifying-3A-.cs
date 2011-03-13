contents: aString notifying: aController 
	"Compile the code in aString and notify aController of any errors. Answer 
	true if compilation succeeds, false otherwise."

	| selectedMessageName compiledSelector |
	selectedMessageName _ selector.
	compiledSelector _ class
							compile: aString
							classified: category
							notifying: aController.
	compiledSelector == nil ifTrue: [^false].
	contents _ aString.
	^true