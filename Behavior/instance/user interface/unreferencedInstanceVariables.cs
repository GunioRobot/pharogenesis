unreferencedInstanceVariables
	"Return a list of the instance variables defined in the receiver which are not referenced in the receiver or any of its subclasses.  2/26/96 sw"

	| any |

	^ self instVarNames copy reject:
		[:ivn | any _ false.
		self withAllSubclasses do:
			[:class |  (class whichSelectorsAccess: ivn) do: 
					[:sel | sel isDoIt ifFalse: [any _ true]]].
		any]

"Ob unreferencedInstanceVariables"