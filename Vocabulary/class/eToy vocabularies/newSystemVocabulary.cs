newSystemVocabulary
	"Answer a Vocabulary object representing significant requests one can make to the Smalltalk object"

	| aVocabulary |
	aVocabulary _ self new.

	aVocabulary vocabularyName: #System.
	aVocabulary documentation: 'Useful messages you might want to send to the current Smalltalk image'.
	aVocabulary initializeFromTable:  #(
(aboutThisSystem none () none (basic queries) 'put up a message describing the system' unused)
(saveAsNewVersion none () none (services) 'advance to the next available image-version number and save the image under that new name' unused znak)
(datedVersion none () String (queries) 'the version of the Squeak system')
(endianness none () String (queries) 'big or little - the byte-ordering of the hardware Squeak is currently running on')
(exitToDebugger none () none (dangerous) 'exits to the host debugger.  Do not use this -- I guarantee you will be sorry.')
(bytesLeft none () Number (basic services) 'perform a garbage collection and answer the number of bytes of free space remaining in the system')
"(browseAllCallsOn: none ((aSelector String)) none (#'queries') 'browse all calls on a selector')
(browseAllImplementorsOf: none ((aSelector String)) none (#'queries') 'browse all implementors of a selector')"

"(allMethodsWithSourceString:matchCase: none ((aString String) (caseSensitive Boolean)) none (queries) 'browse all methods that have the given source string, making the search case-sensitive or not depending on the argument provided.')

(browseMethodsWithString:matchCase: none ((aString String) (caseSensitive Boolean)) none (queries) 'browse all methods that contain the given string in any string literal, making the search case-sensitive or not depending on the argument provided.')

(browseAllImplementorsOf:localTo: none ((aSelector String) (aClass Class)) none (#'queries') 'browse all implementors of a selector that are local to a class')"

).
"(isKindOf: none 	((aClass Class)) Boolean (#'class membership') 'answer whether the receiver''s superclass chain includes aClass')"
	^ aVocabulary

"Vocabulary initialize"
"Vocabulary addStandardVocabulary: Vocabulary newSystemVocabulary"

"SmalltalkImage current basicInspect"
"SmalltalkImage current beViewed"
