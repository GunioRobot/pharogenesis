makeReturnArrow
"Replace the caret character with an arrow"

	| arrowForm arrowCanvas arrowHeadLength arrowX arrowTop arrowBottom |

	arrowForm _ (self characterFormAt: $^) copy.
	arrowCanvas _ arrowForm getCanvas.
	arrowCanvas fillColor: Color white.

	arrowHeadLength _ ((arrowForm width - 2)// 2).
	arrowX _ (arrowHeadLength max: (arrowForm width // 2)).
	arrowTop _ arrowForm height // 4. 
	arrowBottom _ (arrowTop + (arrowForm width * 4 // 5 )).
	arrowBottom _ (arrowBottom min: arrowForm height) max: (arrowForm height * 2 // 3).

	"Draw the lines"
	arrowCanvas line: (arrowX@arrowTop) to: (arrowX@arrowBottom) color: Color black.
	arrowCanvas 
		line: (arrowX@arrowTop) 
		to: ((arrowX - arrowHeadLength)@(arrowTop + arrowHeadLength)) 
		color: Color black.
	arrowCanvas 
		line: (arrowX@arrowTop) 
		to: ((arrowX + arrowHeadLength)@(arrowTop + arrowHeadLength)) 
		color: Color black.

	"Replace the glyph"
	self characterFormAt: $^ put: arrowForm.

