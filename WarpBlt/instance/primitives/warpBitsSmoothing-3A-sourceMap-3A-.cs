warpBitsSmoothing: n sourceMap: sourceMap
	| deltaP12 deltaP43 pA pB deltaPAB sp fixedPtOne picker poker pix nSteps |
	<primitive: 147>
	(width < 1) | (height < 1) ifTrue: [^ self].
	fixedPtOne _ 16384.  "1.0 in fixed-pt representation"
	n > 1 ifTrue:
		[(destForm depth < 16 and: [colorMap == nil])
			ifTrue: ["color map is required to smooth non-RGB dest"
					^ self primitiveFail].
		pix _ Array new: n*n].

	nSteps _ height-1 max: 1.
	deltaP12 _ (self deltaFrom: p1x to: p2x nSteps: nSteps)
			@ (self deltaFrom: p1y to: p2y nSteps: nSteps).
	pA _ (self startFrom: p1x to: p2x offset: nSteps*deltaP12 x)
		@ (self startFrom: p1y to: p2y offset: nSteps*deltaP12 y).
	deltaP43 _ (self deltaFrom: p4x to: p3x nSteps: nSteps)
			@ (self deltaFrom: p4y to: p3y nSteps: nSteps).
	pB _ (self startFrom: p4x to: p3x offset: nSteps*deltaP43 x)
		@ (self startFrom: p4y to: p3y offset: nSteps*deltaP43 y).

	picker _ BitBlt bitPeekerFromForm: sourceForm.
	poker _ BitBlt bitPokerToForm: destForm.
	poker clipRect: self clipRect.
	nSteps _ width-1 max: 1.
	destY to: destY+height-1 do:
		[:y |
		deltaPAB _ (self deltaFrom: pA x to: pB x nSteps: nSteps)
				@ (self deltaFrom: pA y to: pB y nSteps: nSteps).
		sp _ (self startFrom: pA x to: pB x offset: nSteps*deltaPAB x)
			@ (self startFrom: pA y to: pB y offset: nSteps*deltaPAB x).
		destX to: destX+width-1 do:
			[:x | 
			n = 1
			ifTrue:
				[Transcript cr; print: sp // fixedPtOne asPoint.
				poker pixelAt: x@y
						put: (picker pixelAt: sp // fixedPtOne asPoint)]
			ifFalse:
				[0 to: n-1 do:
					[:dx | 0 to: n-1 do:
						[:dy |
						pix at: dx*n+dy+1 put:
								(picker pixelAt: sp
									+ (deltaPAB*dx//n)
									+ (deltaP12*dy//n)
										// fixedPtOne asPoint)]].
				poker pixelAt: x@y put: (self mixPix: pix
										sourceMap: sourceMap
										destMap: colorMap)].
			sp _ sp + deltaPAB].
		pA _ pA + deltaP12.
		pB _ pB + deltaP43]