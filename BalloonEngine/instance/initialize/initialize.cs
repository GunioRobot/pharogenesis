initialize
	| w |
	w _ Display width > 2048 ifTrue: [ 4096 ] ifFalse: [ 2048 ].
	externals _ OrderedCollection new: 100.
	span _ Bitmap new: w.
	bitBlt _ nil.
	self bitBlt: ((BitBlt toForm: Display) destRect: Display boundingBox; yourself).
	forms _ #().
	deferred _ false.