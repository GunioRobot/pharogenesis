openOn: aWorldMorph label: aString
	"Open a view with the given label on the given WorldMorph."
	^ self openOn: aWorldMorph label: aString model: (CautiousModel new initialExtent: aWorldMorph initialExtent)