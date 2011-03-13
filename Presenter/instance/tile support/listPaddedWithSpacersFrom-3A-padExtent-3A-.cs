listPaddedWithSpacersFrom: aList padExtent: padExtent
	| listWithSpacers spacer |
	listWithSpacers _ OrderedCollection new.
	spacer _ Morph newSticky extent: padExtent; color: Color transparent.
	aList do:
		[:aMorph | listWithSpacers add: aMorph.
		listWithSpacers add: spacer deepCopy].
	listWithSpacers size > 1 ifTrue: [listWithSpacers last delete].
	^ listWithSpacers