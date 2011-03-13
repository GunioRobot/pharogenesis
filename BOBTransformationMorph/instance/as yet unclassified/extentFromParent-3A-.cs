extentFromParent: aPoint

	| newExtent |

	submorphs isEmpty ifTrue: [^self extent: aPoint].
	newExtent _ aPoint truncated.
	bounds _ bounds topLeft extent: newExtent.
	newExtent _ self recomputeExtent.
	newExtent ifNil: [^self].
	bounds _ bounds topLeft extent: newExtent.

