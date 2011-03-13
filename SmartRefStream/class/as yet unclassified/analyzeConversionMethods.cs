analyzeConversionMethods
"
SmartRefStream analyzeConversionMethods
"
	| prelim syms good notImps temp impClassName impClass impSignature classesFound tokens goodImps badImps correct answer classBucket goodChanges badChanges impSelector |

	prelim _ Symbol allInstances select: [ :x | 
		(x beginsWith: 'convert') and: [x numArgs = 2]
	].
	syms _ prelim select: [ :x |
		good _ true.
		2 to: x size do: [ :i | good _ good and: [(x at: i) ~~ $: or: [(x at: i - 1) isDigit]]].
		good
	].
	classesFound _ IdentityDictionary new.
	notImps _ OrderedCollection new.
	goodImps _ OrderedCollection new.
	badImps _ OrderedCollection new.
	goodChanges _ ChangeSorter existingOrNewChangeSetNamed: 'valid converters'.
	badChanges _ ChangeSorter existingOrNewChangeSetNamed: 'stale converters'.
	syms do: [ :x | 
		temp _ (Smalltalk allImplementorsOf: x).
		temp size = 0 ifTrue: [
			notImps add: x.
		] ifFalse: [
			temp do: [ :imp |
				tokens _ imp findTokens: ' '.
				impClassName _ tokens first asSymbol.
				impSelector _ tokens second asSymbol.
				impClass _ Smalltalk at: impClassName.
				impSignature _ 
					(String withAll: (impClass allInstVarNames collect: [ :ivn | ivn first])),
					impClass classVersion printString.
				correct _ impSelector endsWith: ':',impSignature,':'.
				(correct ifTrue: [goodImps] ifFalse: [badImps]) add: imp.
				classBucket _ (classesFound 
					at: impClassName 
					ifAbsentPut: [{OrderedCollection new. OrderedCollection new. impClassName}]).
				(correct ifTrue: [classBucket first] ifFalse: [classBucket second]) add: impSelector.
				(correct ifTrue: [goodChanges] ifFalse: [badChanges])
					noteNewMethod: (impClass compiledMethodAt: impSelector) 
					forClass: impClass
					selector: impSelector 
					priorMethod: nil.

			].
		].
		"{temp size. x. temp. impSignature}"
	].
	{syms. notImps. classesFound. goodImps. badImps} explore.
	answer _ WriteStream on: String new.
"=====
	answer cr; nextPutAll: '-- NOT IMPLEMENTED --'; cr; cr.
	notImps asSortedCollection do: [ :x | answer nextPutAll: x; cr].
====="

	answer cr; nextPutAll: '-- STALE IMPLEMENTATIONS --'; cr; cr.
	badImps asSortedCollection do: [ :x | answer nextPutAll: x; cr].
	answer cr; nextPutAll: '-- GOOD IMPLEMENTATIONS --'; cr; cr.
	goodImps asSortedCollection do: [ :x | answer nextPutAll: x; cr].
	answer cr; nextPutAll: '-- CLASS TALLIES --'; cr; cr.
	(classesFound values asSortedCollection: [ :a :b |
		a first size > b first size or: [a first size = b first size and: [a second size > b second size]]
	]) do: [ :each |
		answer nextPutAll: each first size printString,' - ',
			each second size printString,'  ',each third; cr
	]. 

	StringHolder new contents: answer contents; openLabel: 'conversion methods'.
