replaceFrom: start to: stop with: aText displaying: displayBoolean 
	"Compatibility with old Paragraph" 
	text replaceFrom: start to: stop with: aText.		"Update the text."
	self recomposeFrom: start orLineAbove: true