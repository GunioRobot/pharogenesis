makeGalleyStyle

	| all first theRest |

	(self valueOfProperty: #pageBreakRectangles ifAbsent: [#()]) do: [ :each |
		each delete
	].
	self removeProperty: #pageBreakRectangles.
	all _ thePasteUp allTextPlusMorphs.
	first _ all select: [ :x | x predecessor isNil].
	first size = 1 ifFalse: [^self].
	Cursor wait show.
	first _ first first.
	theRest _ all reject: [ :x | x predecessor isNil].
	theRest do: [ :each | each delete].
	first autoFit: true.
	first width: self width - 8.
	first recomposeChain.
	first repositionAnchoredMorphs.
	Cursor normal show.
