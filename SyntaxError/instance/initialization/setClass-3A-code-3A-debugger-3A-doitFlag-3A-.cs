setClass: aClass code: aString debugger: aDebugger doitFlag: flag

	| types printables badChar |
	class _ aClass.
	debugger _ aDebugger.
	selector _ aClass parserClass new parseSelector: aString.
	types _ Scanner classPool at: #TypeTable.	"dictionary"
	printables _ '!@#$%&*-_=+<>{}?/\,•£¢§¶ªº–—“‘”’…ÚæÚ¯˘¿«»`~`' asSet.
	badChar _ aString detect: [:aChar | (types at: aChar asciiValue) == #xBinary and: [
			(printables includes: aChar) not]] ifNone: [nil].
	contents _ badChar 
		ifNil: [aString]
		ifNotNil: ['<<<This string contains a character (ascii value ', 
			badChar asciiValue printString,
			') that is not normally used in code>>> ', aString].
	category ifNil: [category _ aClass organization categoryOfElement: selector].
	category ifNil: [category _ ClassOrganizer default].
	doitFlag _ flag