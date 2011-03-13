tempNames
	"Answer an OrderedCollection of the names of the receiver's temporary 
	variables, which are strings."

	"unused temps at end are not included in method. On the other hand, extra temps such as to:do: loop limit are added to method"
	| tempNames n |
	tempNames _ self methodNode tempNames.
	n _ self method numTemps.
	tempNames size = n ifTrue: [^ tempNames].
	tempNames size > n ifTrue: [^ tempNames first: n].
	tempNames size + 1 to: n do: [:i |
		tempNames _ tempNames copyWith: 't' , i printString].
	^ tempNames