convertApril2000: varDict using: smartRefStrm
	| cls info selector pair classChanges methodChanges methodRemoves classRemoves |
	"These variables are automatically stored into the new instance:
		('name' 'preamble' 'postscript' 'structures' 'superclasses' ).
	This method is for additional changes.
	It initializes the isolation variables, and then duplicates the logic fo
		assimilateAllChangesFoundIn:."

	revertable _ false.
	isolationSet _ nil.
	isolatedProject _ nil.
	changeRecords _ Dictionary new.

	classChanges _ varDict at: 'classChanges'.
	classChanges keysDo:
		[:className |
	  	(cls _ Smalltalk classNamed: className) ifNotNil:
			[info _ classChanges at: className ifAbsent: [Set new].
			info do: [:each | self atClass: cls add: each]]].

	methodChanges _ varDict at: 'methodChanges'.
	methodRemoves _ varDict at: 'methodRemoves'.
	methodChanges keysDo:
		[:className |
	  	(cls _ Smalltalk classNamed: className) ifNotNil:
			[info _ methodChanges at: className ifAbsent: [Dictionary new].
			info associationsDo:
				[:assoc | selector _ assoc key.
				(assoc value == #remove or: [assoc value == #addedThenRemoved])
					ifTrue:
						[assoc value == #addedThenRemoved
							ifTrue: [self atSelector: selector class: cls put: #add].
						pair _ methodRemoves at: {cls name. selector} ifAbsent: [nil] .
						self removeSelector: selector class: cls priorMethod: nil lastMethodInfo: pair]
					ifFalse: 
						[self atSelector: selector class: cls put: assoc value]]]].

	classRemoves _ varDict at: 'classRemoves'.
	classRemoves do:
		[:className | self noteRemovalOf: className].

