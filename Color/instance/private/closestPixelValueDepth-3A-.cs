closestPixelValueDepth: depth
	"Return the nearest approximation to this color for this depth of Form.  Depth can be 1, 2, 4, or 8.  This method is for when we go to L*a*b* color space.  For now use the faster version. 6/14/96 tk"
	|  least r g b col rdiff gdiff bdiff diff leastIndex |

	depth > 256 ifTrue: [^ self error: 'depth must be 1, 2, 4, or 8'].
	least _ ComponentMask*ComponentMask*3 + 100.		"start with max"
	r _ self privateRed.  g _ self privateGreen.  b _ self privateBlue.
	0 to: (1 bitShift: depth) - 1 do: [:ind |
		col _ IndexedColors at: ind+1.
		rdiff _ r - col privateRed.
		gdiff _ g - col privateGreen.
		bdiff _ b - col privateBlue.
		diff _ (rdiff*rdiff) + (gdiff*gdiff) + (bdiff*bdiff).
		diff < least ifTrue: [
			least _ diff.
			leastIndex _ ind]].
	^ leastIndex