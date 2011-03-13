extractFeatures | xl xr yl yh reg px py |
"get extent bounding box"	in _ bmax - bmin. 

"Look for degenerate forms first: . - |"
"look for a dot"				in < (3@3) ifTrue: [^' dot... '].

"Feature 5: turns (these are already in ftrs)"

"Feature 4: absolute size"	in < (10@10) ifTrue: [ftrs _  'SML ', ftrs] ifFalse:
							[in <=  (70@70) ifTrue: [ftrs _ 'REG ', ftrs] ifFalse:
							[in > (70@70) ifTrue: [ftrs _ 'LRG ', ftrs]]].

"Feature 3: aspect ratio"
	"horizontal shape"		((in y = 0) or: [(in x/in y) abs > 3]) ifTrue:
								[ftrs _ 'HOR ', ftrs] ifFalse:
	"vertical shape"			[((in x = 0) or: [(in y/in x) abs >= 3]) ifTrue:
								[ftrs _ 'VER ', ftrs] ifFalse:
	"boxy shape"			[((in x/in y) abs <= 3) ifTrue:
								[ftrs _ 'BOX ', ftrs.
"Now only for boxes"
"Feature 2: endstroke reg"	ftrs _ (self regionOf: (pts last)), ftrs.
							
"Feature 1: startstroke reg"	ftrs _ (self regionOf: (pts contents at: 1)), ftrs.]]].

^ftrs



