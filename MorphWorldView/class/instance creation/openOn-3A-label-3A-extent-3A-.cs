openOn: aWorldMorph label: aString extent: aPoint
	"Open a view with the given label and extent on the given WorldMorph."

	^ self openOn: aWorldMorph
		label: aString
		model: (CautiousModel new initialExtent: aPoint)
