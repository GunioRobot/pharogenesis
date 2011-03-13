readArray
	"PRIVATE -- Read the contents of an Array.
	 We must do beginReference: here after instantiating the Array
	 but before reading its contents, in case the contents reference
	 the Array. beginReference: will be sent again when we return to
	 next, but that�s ok as long as we save and restore the current
	 reference position over recursive calls to next."
	| count array refPosn |

	count _ byteStream nextNumber: 4.

	refPosn _ self beginReference: (array _ Array new: count).
	1 to: count do: [:i |
		array at: i put: self next].
	self setCurrentReference: refPosn.
	^ array