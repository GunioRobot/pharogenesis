dockUpToInstance: anInstance
	"The enclosing PasteUpMorph's current instance has changed (i.e., a new card is been 'gone to'), so do what is necessary"
	| oldTarget |
	self flag: #deferred.  "Not ready for use"
	oldTarget _ target.
	target _ anInstance.
	self  readFromTarget.
	contents == nil ifTrue: [contents _ '<new>'].
	getSelector == nil ifTrue: [self isThisEverCalled].
	oldTarget == target ifFalse: [oldTarget updateAllViewers]