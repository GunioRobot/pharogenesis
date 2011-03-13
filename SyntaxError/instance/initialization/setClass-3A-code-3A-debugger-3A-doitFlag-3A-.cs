setClass: aClass code: aString debugger: aDebugger doitFlag: flag

	| types printables badChar |
	class := aClass.
	debugger := aDebugger.
	selector := aClass parserClass new parseSelector: aString.
	types := Scanner classPool at: #TypeTable.	"dictionary"
	printables := '!@#$%&*-_=+<>{}?/\,·£¢§¶ªºÚæÚ¯×¿«»`~`' asSet.
	badChar := aString detect: [:aChar | (types at: aChar asciiValue ifAbsent: [#xLetter]) == #xBinary and: [
			(printables includes: aChar) not]] ifNone: [nil].
	contents := badChar 
		ifNil: [aString]
		ifNotNil: ['<<<This string contains a character (ascii value ', 
			badChar asciiValue printString,
			') that is not normally used in code>>> ', aString].
	category ifNil: [category := aClass organization categoryOfElement: selector].
	category ifNil: [category := ClassOrganizer default].
	doitFlag := flag