classInit
	"Set the order of the colors to show the user.  (MineToStd at: index-of-square) = place of that color in Color indexedColors.  
	ColorMemoryMorph new classInit"

	| grays hues |
	grays _ #(1 16 17 18 10 19 20 "83" 21 11 22 23 24 12 "126" 25 26 27 3 28 29 30 "169" 13 31 32 33 14 34 "212" 35 36 15 37 38 39 2).	"0-order"
	hues _ (Color indexedColors copyFrom: 41 to: 256) sortBy: [:a :b | a brightness < b brightness].
"	hues _ hues sortBy: [:a :b | a hue < b hue]."
	hues _ hues collect: [:aColor | (aColor pixelValueForDepth: 8)].
	MineToStd _ (grays, hues, #(0 0 0 0 0 0 0)) collect: [:each | each + 1].
	StdToMine _ Array new: 256 withAll: 256.
	MineToStd doWithIndex: [:each :ind | StdToMine at: each put: ind].