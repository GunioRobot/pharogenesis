openOn: aWorldMorph label: aString cautionOnClose: aBoolean
	"Open a view with the given label on the given WorldMorph."
	| aModel |
	aModel _ aBoolean
		ifTrue:		[CautiousModel new]
		ifFalse:		[WorldViewModel new].
	^ self openOn: aWorldMorph label: aString model: (aModel initialExtent: aWorldMorph initialExtent)