borderWidth: bw
	| newExtent |
	newExtent _ 2 * bw + image extent.
	bounds extent = newExtent ifFalse:[super extent: newExtent].
	super borderWidth: bw