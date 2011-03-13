setClass: aClass code: aString debugger: aDebugger

	class _ aClass.
	debugger _ aDebugger.
	"the debugger is just for proceeding"
	selector _ aClass parserClass new parseSelector: aString.
	contents _ aString.
	category == nil ifTrue: [
		category _ aClass organization categoryOfElement: selector].
	category == nil ifTrue: [category _ ClassOrganizer default].
	selectionIndex _ 1