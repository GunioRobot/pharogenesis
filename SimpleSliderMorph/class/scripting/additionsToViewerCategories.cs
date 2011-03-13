additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ #(
(slider (

(slot numericValue 'A number representing the current position of the knob.' number readWrite player getNumericValue player setNumericValue:)

(slot minVal	 'The number represented when the knob is at the left or top of the slider; the smallest value returned by the slider.' number readWrite	player getMinVal player setMinVal:)

(slot maxVal 'The number represented when the knob is at the right or bottom of the slider; the largest value returned by the slider.' number readWrite	player getMaxVal player setMaxVal:)

(slot descending 'Tells whether the smallest value is at the top/left (descending = false) or at the bottom/right (descending = true)' boolean readWrite player getDescending player setDescending:)

(slot truncate 'If true, only whole numbers are used as values; if false, fractional values are allowed.' boolean readWrite	player getTruncate player setTruncate:)

(slot color 'The color of the slider' color readWrite player getColor  player  setColor:)

(slot knobColor 'The color of the slider' color readWrite player getKnobColor player setKnobColor:)
(slot  width  'The width' number readWrite player getWidth  player  setWidth:)
(slot  height  'The height' number readWrite player getRight  player  setHeight:)))

(basic	(
(slot numericValue 'A number representing the current position of the knob.' number readWrite player getNumericValue player setNumericValue:))))

