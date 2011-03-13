aJunkMethod: aMorph event: evt 
	"For the moment, you edited 1 have to drop it the right place. We do not 	look at enclosing morphs"
	| itNoun |
	
	itNoun  _  (aMorph isNoun ) .
	(self withAllOwnersDo: [:m |
		 (((m isSyntaxMorph ) and: [(m isBlockNode ).
			]  ) ifTrue: [((m stopStepping ) hideCaret ).
			]    ).
		] ).
	(1 abs  ; + itNoun  ).
	((6 + 5  ; - 6  ) abs  ; - 5  ).
	^  self 
	
	