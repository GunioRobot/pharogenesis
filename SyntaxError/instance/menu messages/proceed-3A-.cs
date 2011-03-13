proceed: aController 
	"The error has presumably been fixed and the file in that created the 
	syntax error can now be continued."

	| d |
	d _ debugger. debugger _ nil.  "break cycle"
	d proceed: aController