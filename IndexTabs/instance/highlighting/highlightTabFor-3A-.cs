highlightTabFor: aBook
	| theOne |
	self tabMorphs do: [:m |
		(m morphToInstall == aBook)
				ifTrue: [m highlight.  theOne _ m]
				ifFalse: [m unHighlight]].
	^ theOne
