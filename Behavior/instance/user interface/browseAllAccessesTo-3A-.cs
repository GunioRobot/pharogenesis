browseAllAccessesTo: instVarName 	"Collection browseAllAccessesTo: 'contents'."
	"Create and schedule a Message Set browser for all the receiver's methods 
	or any methods of a subclass that refer to the instance variable name."
	| coll |
	coll _ OrderedCollection new.
	Cursor wait 
		showWhile: 
			[self withAllSubclasses do:
				[:class | 
				(class whichSelectorsAccess: instVarName) do: 
					[:sel | sel ~~ #DoIt ifTrue: [coll add: class name , ' ' , sel]]].
			self allSuperclasses do:
				[:class | 
				(class whichSelectorsAccess: instVarName) do: 
					[:sel | sel ~~ #DoIt ifTrue: [coll add: class name , ' ' , sel]]]].
	^ Smalltalk browseMessageList: coll name: 'Accesses to ' , instVarName autoSelect: instVarName