embeddedMorphs
	"return the list of morphs embedded in me"
	| morphs |
	morphs _ IdentitySet new.
	runs withStartStopAndValueDo: [ :start :stop :attribs | attribs do: [ :attrib |
		(attrib isKindOf: TextAnchor) ifTrue: [  morphs add: attrib anchoredMorph ] ] ].
	^morphs select: [ :m | m isKindOf: Morph ]