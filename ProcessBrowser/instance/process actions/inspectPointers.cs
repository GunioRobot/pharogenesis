inspectPointers
	| tc pointers |
	selectedProcess
		ifNil: [^ self].
	tc _ thisContext.
			pointers _ Smalltalk pointersTo: selectedProcess except: {self processList. tc. self}.
			pointers isEmpty
				ifTrue: [^ self].
			OrderedCollectionInspector
				openOn: pointers
				withEvalPane: false
				withLabel: 'Objects pointing to ' , selectedProcess browserPrintString
