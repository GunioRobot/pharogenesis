revealPlayerIn: aWorld
	| aMorph |
	(aMorph _ self costume) isInWorld ifTrue: [^ aMorph goHome].

	"It's hidden somewhere; search for it"
	aWorld submorphs do:
		[:m | (m succeededInRevealing: self) ifTrue: [^ self]].

	self inform: 
'Sorry.  Unaccountably, this object
seems to be irretrievably lost'

	
	
	