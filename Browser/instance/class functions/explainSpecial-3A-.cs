explainSpecial: string 
	"Answer a string explaining the code pane selection if it is displaying 
	one of the special edit functions."

	| classes whole lits reply |
	(editSelection == #editClass or: [editSelection == #newClass])
		ifTrue: 
			["Selector parts in class definition"
			string last == $: ifFalse: [^nil].
			lits _ Array with:
				#subclass:instanceVariableNames:classVariableNames:poolDictionaries:category:.
			(whole _ lits detect: [:each | (each keywords
					detect: [:frag | frag = string] ifNone: []) ~~ nil]
						ifNone: []) ~~ nil
				ifTrue: [reply _ '"' , string , ' is one part of the message selector ' , whole , '.']
				ifFalse: [^nil].
			classes _ self systemNavigation allClassesImplementing: whole.
			classes _ 'these classes ' , classes printString.
			^reply , '  It is defined in ' , classes , '."
Smalltalk browseAllImplementorsOf: #' , whole].

	editSelection == #hierarchy
		ifTrue: 
			["Instance variables in subclasses"
			classes _ self selectedClassOrMetaClass allSubclasses.
			classes _ classes detect: [:each | (each instVarNames
						detect: [:name | name = string] ifNone: []) ~~ nil]
					ifNone: [^nil].
			classes _ classes printString.
			^'"is an instance variable in class ' , classes , '."
' , classes , ' browseAllAccessesTo: ''' , string , '''.'].
	editSelection == #editSystemCategories ifTrue: [^nil].
	editSelection == #editMessageCategories ifTrue: [^nil].
	^nil