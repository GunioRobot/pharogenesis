clipPolygonFrontFrom: buf1 to: buf2 count: n
	| last next t outIndex inLast inNext outVtx |
	outIndex _ 0.
	last _ buf1 at: n.
	inLast _ last clipFlags anyMask: InFrontBit.
	1 to: n do:[:i|
		next _ buf1 at: i.
		inNext _ next clipFlags anyMask: InFrontBit.
		inLast = inNext ifFalse:["Passes clip boundary"
			t _ self frontClipValueFrom: last to: next.
			outVtx _ self interpolateFrom: last to: next at: t.
			buf2 at: (outIndex _ outIndex+1) put: outVtx].
		inNext ifTrue:[buf2 at: (outIndex _ outIndex+1) put: next].
		last _ next.
		inLast _ inNext.
	].
	^outIndex