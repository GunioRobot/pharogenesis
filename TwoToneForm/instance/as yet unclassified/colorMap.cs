colorMap
	"An Array of Colors, can't go to a Bitmap without knowing the destination depth.  6/24/96 tk"
	^ Array with: backgroundColor with: foregroundColor

"	| fore back |
	fore _ foregroundColor bitPatternForDepth: depth.
	back _ backgroundColor bitPatternForDepth: depth.
	^ Bitmap with: back first with: fore first.
"