originate: aPoint on: destForm
	"Answer a new Color whose bits have been wrapped around
	so that, if they represent a stipple, it will appear at aPoint the
	same as THIS color appears at 0@0.  6/24/96 tk"

	| newArray |
	newArray _ Array2D new extent: colorArray2D extent.
	1 to: newArray width do: [:i |
		1 to: newArray height do: [:j |
			newArray at: (i-1 + aPoint x \\ self width + 1) 
				at: (j-1 + aPoint y \\ self height + 1) 
				put: (colorArray2D at: i at: j)]].
	^ self class array2D: newArray

"	1 to: self size do:
		[:i | newColor at: i-1 + aPoint y \\ self size + 1
					put: (self originateWord: (self at: i)
								to: aPoint x on: destForm)].
"
