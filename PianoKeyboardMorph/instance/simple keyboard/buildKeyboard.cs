buildKeyboard
	| wtWid bkWid keyRect octavePt nWhite nBlack |
	self removeAllMorphs.
	wtWid _ 8. bkWid _ 5.
	self extent: 10@10.
	1 to: nOctaves+1 do:
		[:i | i <= nOctaves ifTrue: [nWhite _ 7.  nBlack _ 5]
						ifFalse: [nWhite _ 1.  nBlack _ 0 "High C"].
		octavePt _ self innerBounds topLeft + ((7*wtWid*(i-1)-1)@-1).
		1 to: nWhite do:
			[:j | keyRect _ octavePt + (j-1*wtWid@0) extent: (wtWid+1)@36.
			self addMorph: ((RectangleMorph newBounds: keyRect color: whiteKeyColor)
								borderWidth: 1;
				on: #mouseDown send: #mouseDownPitch:event:noteMorph: to: self
								withValue: i-1*12 + (#(1 3 5 6 8 10 12) at: j))].
		1 to: nBlack do:
			[:j | keyRect _ octavePt + ((#(6 15 29 38 47) at: j)@1) extent: bkWid@21.
			self addMorph: ((Morph newBounds: keyRect color: blackKeyColor)
				on: #mouseDown send: #mouseDownPitch:event:noteMorph: to: self
								withValue: i-1*12 + (#(2 4 7 9 11) at: j))]].
	self submorphsDo:
		[:m | m on: #mouseMove send: #mouseMovePitch:event:noteMorph: to: self;
				on: #mouseUp send: #mouseUpPitch:event:noteMorph: to: self;
				on: #mouseEnterDragging send: #mouseDownPitch:event:noteMorph: to: self;
				on: #mouseLeaveDragging send: #mouseUpPitch:event:noteMorph: to: self].
	self extent: (self fullBounds extent + borderWidth - 1)