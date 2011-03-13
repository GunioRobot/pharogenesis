extent: aPoint

	| newExtent |

	newExtent _ aPoint truncated.
	bounds extent = newExtent ifTrue: [^self].
	bounds _ bounds topLeft extent: newExtent.
	"self recomputeExtent."

