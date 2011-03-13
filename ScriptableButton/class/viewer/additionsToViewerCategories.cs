additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ #((button (
			(slot label 'The wording on the button' string readWrite player getLabel player setLabel:)
			(slot color 'The color of the object' color readWrite player getColor  player  setColor:)
			(slot height  'The height' number readWrite player getHeight  player  setHeight:) 
			(slot borderColor 'The color of the object''s border' color readWrite player getBorderColor player  setBorderColor:)
			(slot borderWidth 'The width of the object''s border' number readWrite player getBorderWidth player setBorderWidth:)
			(slot  height  'The height' number readWrite player getHeight  player  setHeight:)
			(slot roundedCorners 'Whether corners should be rounded' boolean readWrite player getRoundedCorners player setRoundedCorners:) 
			(slot actWhen 'When the script should fire' buttonPhase  readWrite player getActWhen player setActWhen: ))))


