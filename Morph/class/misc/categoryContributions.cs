categoryContributions
	"Answer a list of arrays which characterize the elements in various viewer categories for the etoy system.  Implementors of this method are statically polled to contribute this information when the scripting system reinitializes its scripting info, which typically only happens after a structural change.

	Each array returned has two elements.  The first is the category name, and the second is a an array of <elementType> <elementName> pairs, where <elementType is #slot or #script"

	^ #(
		('basic' ((slot x) (slot y) (slot heading) (script forward:)
				 (script turn:) (script beep:) ))

		('color & border'( (slot color) (slot colorUnder) (slot borderColor) (slot borderWidth)))

		('geometry'  ((slot scaleFactor) (slot left) (slot right) (slot top) (slot bottom) (slot width) (slot height) (slot x) (slot y) (slot heading)))

		('miscellaneous' ((script doMenuItem:) (script show) (script hide) (script wearCostumeOf:) (script startScript:) (script stopScript:) (script pauseScript:)))

		('motion' ((slot x) (slot y) (slot heading) (script forward:) (script moveToward:) (script turn:) (script bounce:) (script wrap) (script followPath) (script goToRightOf:)))

		('pen use' ((slot penColor) (slot penSize) (slot penDown)))

		('tests' ((slot isOverColor) (slot isUnderMouse) (slot colorSees))))
