provideDefaultFlapIDBasedOn: aStem
	"Provide the receiver with a default flap id"

	| aNumber usedIDs anID  |
	aNumber _ 0.
	usedIDs _ FlapTab allSubInstances select: [:f | f ~~ self] thenCollect: [:f | f flapIDOrNil].
	anID _ aStem.
	[usedIDs includes: anID] whileTrue:
		[aNumber _ aNumber + 1.
		anID _ aStem, (aNumber asString)].
	self flapID: anID.
	^ anID