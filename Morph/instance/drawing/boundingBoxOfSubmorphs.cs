boundingBoxOfSubmorphs
	| aBox |
	aBox _ bounds origin extent: self minimumExtent.  "so won't end up with something empty"
	submorphs do:
		[:m | m visible ifTrue: [aBox _ aBox quickMerge: m fullBounds]].
	^ aBox
