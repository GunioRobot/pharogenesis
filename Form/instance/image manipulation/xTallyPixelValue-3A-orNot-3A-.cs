xTallyPixelValue: pv orNot: not
	"Return an array of the number of pixels with value pv by x-value.
	Note that if not is true, then this will tally those different from pv."
	| cm slice |
	cm _ self newColorMap.		"Map all colors but pv to zero"
	not ifTrue: [cm atAllPut: 1].		"... or all but pv to one"
	cm at: pv+1 put: 1 - (cm at: pv+1).
	slice _ Form extent: 1@height.
	^ (0 to: width-1) collect:
		[:x |
		slice copyBits: (x@0 extent: 1@height) from: self at: 0@0
			colorMap: cm.
		slice primCountBits]