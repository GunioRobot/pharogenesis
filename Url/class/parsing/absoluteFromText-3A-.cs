absoluteFromText: aString
	"Return a URL from a string and handle
	a String without a scheme as a HttpUrl."

	"Url absoluteFromText: 'http://chaos.resnet.gatech.edu:8000/docs/java/index.html?A%20query%20#part'" 
	"Url absoluteFromText: 'msw://chaos.resnet.gatech.edu:9000/testbook?top'"
	"Url absoluteFromText: 'telnet:chaos.resnet.gatech.edu'"
	"Url absoluteFromText: 'file:/etc/passwd'"

	| remainder index scheme fragment newUrl |
	"trim surrounding whitespace"
	remainder _ aString withBlanksTrimmed.	

	"extract the fragment, if any"
	index _ remainder indexOf: $#.
	index > 0 ifTrue: [
		fragment _ remainder copyFrom: index + 1 to: remainder size.
		remainder _ remainder copyFrom: 1 to: index - 1].

	"choose class based on the scheme name, and let that class do the bulk of the parsing"
	scheme _ self schemeNameForString: remainder.
	newUrl _ (self urlClassForScheme: scheme) new privateInitializeFromText: remainder.
	newUrl privateFragment: fragment.
	^newUrl