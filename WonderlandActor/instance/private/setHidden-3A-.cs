setHidden: aBoolean
	"Set the object's hidden status (including its parts)"

	hidden _ aBoolean.

	"Set the show/hide status of our parts"
	myChildren do: [:child | (child isPart) ifTrue: [child setHidden: aBoolean] ].
