addMorphFront: aMorph fromWorldPosition: wp 
	"Overridden for more specific re-layout and positioning"
	| i |
	self addMorphFront: aMorph.
	i _ (self paragraph characterBlockAtPoint: (self transformFromWorld globalPointToLocal: wp))
		stringIndex.
	self paragraph replaceFrom: i to: i-1
		with: (Text string: '*' attribute: (TextAnchor new anchoredMorph: aMorph))
		displaying: false.
	self fit