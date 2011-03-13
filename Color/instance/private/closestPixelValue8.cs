closestPixelValue8
	"Return the index in the standard 8-bit colormap for the nearest match to this color.  Find the closest color in our 6x6x6 color cube.  See if any of the grays are closer to the real color.  6/14/96 tk"
	| r g b rr gg bb diff gray val diffg diffc pvtGray rd gd bd |

	rgb = 0 ifTrue: [^ 1].	"Special case for black, very common"
	rgb = 16r3FFFFFFF ifTrue: [^ 0].
		"Special case for white, very common"
	"Find the closest color in our 6x6x6 color cube. Integers in [0..5]" 
	r _ (((self privateRed    * 5) + HalfComponentMask) // ComponentMask).
	g _ (((self privateGreen * 5) + HalfComponentMask) // ComponentMask).
	b _ (((self privateBlue    * 5) + HalfComponentMask) // ComponentMask).

	rr _ self privateRed.  gg _ self privateGreen.  bb _ self privateBlue.
	diff _ ((rr-gg)*(rr-gg)) + ((gg-bb)*(gg-bb)) + ((bb-rr)*(bb-rr)).	"least squares"
	"If diff is big, r g and b not very close, not very much like a gray.  One 6x6x6 step is 1023.0 / 5.0 = 204.6.  Squared is 204.6 * 204.6 =  41861.2
	 Return a color from our cube that starts at index 40." 
	diff >= 41861 ifTrue: [^ (r * 36) + (b * 6) + g + 40].

	"Consider using a gray"
	pvtGray _ rr+gg+bb //3.		"[0..1023]"
	gray _ (((pvtGray* 32) + HalfComponentMask) // ComponentMask).
		"33 discrete gray levels [0..32]"
	val _ pvtGray.
	"Do error comparison in 1023 space"
	diffg _ ((val - rr)*(val - rr)) + ((val - gg)*(val - gg)) + 
			((val - bb)*(val - bb)).	"error in the Gray"

	"Color in the cube [0..5], blown back up to [0..1023] with error"
	rd _ (r * ComponentMask) // 5.	
	gd _ (g * ComponentMask) // 5.
	bd _ (b * ComponentMask) // 5.
	diffc _ ((rd - rr)*(rd - rr)) + ((gd - gg)*(gd - gg)) + ((bd - bb)*(bd - bb)).
			"error in the color from the cube"
	"self halt."
	diffg < diffc
		ifTrue: ["33 grays.  eighths starting at index 9, 32nds from 16 to 39"
			^ #(1 16 17 18 9 19 20 21 10 22 23 24 11 25 26 27 12 
				 28 29 30 13 31 32 33 14 34 35 36 15 37 38 39 0) at: gray+1]
		ifFalse: [^ (r * 36) + (b * 6) + g + 40]
