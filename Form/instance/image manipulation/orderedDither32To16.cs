orderedDither32To16
	"Do an ordered dithering for converting from 32 to 16 bit depth."
	| ditherMatrix ii out inBits outBits index pv dmv r di dmi dmo g b pvOut outIndex |
	self depth = 32 ifFalse:[^self error:'Must be 32bit for this'].
	ditherMatrix _ #(	0	8	2	10
						12	4	14	6
						3	11	1	9
						15	7	13	5).
	ii _ (0 to: 31) collect:[:i| i].
	out _ Form extent: self extent depth: 16.
	inBits _ self bits.
	outBits _ out bits.
	index _ outIndex _ 0.
	pvOut _ 0.
	0 to: self height-1 do:[:y|
		0 to: self width-1 do:[:x|
			pv _ inBits at: (index _ index + 1).
			dmv _ ditherMatrix at: (y bitAnd: 3) * 4 + (x bitAnd: 3) + 1.
			r _ pv bitAnd: 255.	di _ r * 496 bitShift: -8.
			dmi _ di bitAnd: 15.	dmo _ di bitShift: -4.
			r _ dmv < dmi ifTrue:[ii at: 2+dmo] ifFalse:[ii at: 1+dmo].
			g _ (pv bitShift: -8) bitAnd: 255.	di _ g * 496 bitShift: -8.
			dmi _ di bitAnd: 15.	dmo _ di bitShift: -4.
			g _ dmv < dmi ifTrue:[ii at: 2+dmo] ifFalse:[ii at: 1+dmo].
			b _ (pv bitShift: -16) bitAnd: 255.	di _ b * 496 bitShift: -8.
			dmi _ di bitAnd: 15.	dmo _ di bitShift: -4.
			b _ dmv < dmi ifTrue:[ii at: 2+dmo] ifFalse:[ii at: 1+dmo].
			pvOut _ (pvOut bitShift: 16) + 
						(b bitShift: 10) + (g bitShift: 5) + r.
			(x bitAnd: 1) = 1 ifTrue:[
				outBits at: (outIndex _ outIndex+1) put: pvOut.
				pvOut _ 0].
		].
		(self width bitAnd: 1) = 1 ifTrue:[
			outBits at: (outIndex _ outIndex+1) put: (pvOut bitShift: -16).
			pvOut _ 0].
	].
	^out