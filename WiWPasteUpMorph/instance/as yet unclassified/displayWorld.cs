displayWorld

	"RAA 27 Nov 99 - if we are not active, then the parent should do the drawing"

	self flag: #bob.			"probably not needed"

	World == self ifTrue: [^super displayWorld].
	parentWorld ifNotNil: [^parentWorld displayWorld].
	^super displayWorld		"in case MVC needs it"