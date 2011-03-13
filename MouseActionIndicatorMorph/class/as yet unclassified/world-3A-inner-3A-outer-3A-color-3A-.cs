world: aWorld inner: innerRectangle outer: outerRectangle color: aColor

	| allRects allMorphs |

	allRects _ outerRectangle areasOutside: innerRectangle.
	allMorphs _ allRects collect: [ :each |
		self new bounds: each; color: aColor
	].
	allMorphs do: [ :each |
		each siblings: allMorphs; openInWorld: aWorld
	].
	^allMorphs


