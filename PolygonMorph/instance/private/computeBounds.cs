computeBounds
	| oldBounds delta excludeHandles |
	vertices ifNil: [^ self].

	self changed.
	oldBounds _ bounds.
	self releaseCachedState.
	bounds _ self curveBounds truncated.
	self arrowForms do:
		[:f | bounds _ bounds merge: (f offset extent: f extent)].
	handles ifNotNil: [self updateHandles].

	"since we are directly updating bounds, see if any ordinary submorphs exist and move them accordingly"
	(oldBounds notNil and: [(delta _ bounds origin - oldBounds origin) ~= (0@0)]) ifTrue: [
		excludeHandles _ IdentitySet new.
		handles ifNotNil: [excludeHandles addAll: handles].
		self submorphsDo: [ :each |
			(excludeHandles includes: each) ifFalse: [
				each position: each position + delta
			].
		].
	].
	self layoutChanged.
	self changed.
