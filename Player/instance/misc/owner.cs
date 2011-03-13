owner
	"Answer the player who wears my costume's owner as its costume"
	| itsOwner |
	costume ifNotNil:
		[(itsOwner _ costume owner) ifNotNil:
			[^ itsOwner costumee]].
	^ nil