getChildNamed: childName
	"Returns the child with the specified name if it is a child of this object"

	| theChild nameParts |

	childName at: 1 put: ((childName at: 1) asLowercase).

	"First see if they're looking for me"
	(myName = childName) ifTrue: [ ^ self ].

	nameParts _ childName findTokens: ' '.
	nameParts do: [:name | name at: 1 put: ((name at: 1) asLowercase) ].

	((nameParts first) = myName) ifTrue: [ nameParts removeFirst ].
	theChild _ self.
	nameParts do: [:aName | theChild _ theChild perform: (aName asSymbol) ].
	^ theChild.