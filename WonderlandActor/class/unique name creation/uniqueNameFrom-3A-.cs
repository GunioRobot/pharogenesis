uniqueNameFrom: aName
	"If aName is not an instance variable of this class, returns aName.  Otherwise it returns a unique name based on aName that is not an instance var."

	| index |

	(self instVarNames includes: aName) ifFalse: [ ^ aName ].

	index _ 2.
	[ self instVarNames includes: (aName , (index asString)) ]
		whileTrue: [ index _ index + 1 ].

	^ aName , (index asString).
	