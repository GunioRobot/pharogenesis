allUnreferencedInstanceVariables
	"Return a list of the instance variables known to the receiver which are not referenced in the receiver or any of its subclasses OR superclasses"

	| any definingClass |

	^ self allInstVarNames copy reject:
		[:ivn | any _ false.
		definingClass _ self classThatDefinesInstanceVariable: ivn.
		definingClass withAllSubclasses do:
			[:class |  any ifFalse:
				[(class whichSelectorsAccess: ivn asSymbol) do: 
					[:sel | sel isDoIt ifFalse: [any _ true]]]].
			any]