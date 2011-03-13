makeAssignArrow
"Replace the underline character with an arrow for this font"

	| arrowForm arrowCanvas arrowY arrowLeft arrowRight arrowHeadLength |

	arrowForm _ (self characterFormAt: $_) copy.
	arrowCanvas _ arrowForm getCanvas.
	arrowCanvas fillColor: Color white.
	arrowY _ arrowForm height // 2.
	arrowLeft _ 0. 
	arrowRight _ arrowForm width - 2.
	arrowHeadLength _ (arrowRight - arrowLeft) * 2 // 5.
	"Draw the lines"
	arrowCanvas line: (arrowLeft@arrowY) to: (arrowRight@arrowY) color: Color black.
	arrowCanvas 
		line: (arrowLeft@arrowY) 
		to: ((arrowLeft + arrowHeadLength)@(arrowY - arrowHeadLength)) 
		color: Color black.
	arrowCanvas 
		line: (arrowLeft@arrowY) 
		to: ((arrowLeft + arrowHeadLength)@(arrowY + arrowHeadLength)) 
		color: Color black.

	"Replace the glyph"
	self characterFormAt: $_ put: arrowForm.

