step

	boundsSeq isEmpty ifTrue:
		["If all done, then grant one final request and vanish"
		finalAction value.
		^ self delete].

	"Otherwise, zoom to the next rectangle"
	self zoomTo: boundsSeq removeFirst