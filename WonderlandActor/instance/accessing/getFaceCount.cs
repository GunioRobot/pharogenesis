getFaceCount
	"Return the number of faces in this actor and its parts"

	| count |

	(myMesh notNil) ifTrue: [ count _ myMesh faces size ]
					 ifFalse: [ count _ 0 ].

	myChildren do: [:child | (child isPart) ifTrue: [ count _ count + (child getFaceCount) ] ].

	^ count.
