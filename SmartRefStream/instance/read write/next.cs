next
	"Really write three objects: (version, class structure, object). But only when called from the outside.  "

	| version ss object |
	^ topCall == nil 
		ifTrue: 
			[topCall _ #marked.
			version _ super next.
			version class == SmallInteger ifFalse: [^ version].	
				"version number, else just a regular object, not in our format, "
			ss _ super next.
			ss class == Array ifFalse: [^ ss].  "just a regualr object"
			(ss at: 1) = 'class structure' ifFalse: [^ ss].
			structures _ ss at: 2.
			superclasses _ (ss size > 3 and: [(ss at: 3) = 'superclasses']) 
				ifTrue: [ss at: 4]		"class name -> superclass name"
				ifFalse: [Dictionary new].
			(self verifyStructure = 'conversion method needed') ifTrue: [^ nil].
			object _ super next.	"all the action here"
			self restoreClassInstVars.		"for UniClasses. version 4"

			topCall _ nil.	"reset it"
			object]
		ifFalse:
			[super next]
