setClass: aClass code: aString debugger: aDebugger

	class _ aClass.
	debugger _ aDebugger.
	selector _ aClass parserClass new parseSelector: aString.
	contents _ aString.
	category ifNil: [category _ aClass organization categoryOfElement: selector].
	category ifNil: [category _ ClassOrganizer default].
