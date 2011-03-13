additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ #(

	(basic (
(slot cursor 	'The current cursor location, wrapped back to the beginning if appropriate' number	 readWrite player getCursor player setCursorWrapped:)

(slot sampleAtCursor	'The sample value at the current cursor location' number readWrite player getSampleAtCursor player setSampleAtCursor:)))

	(sampling (
(slot cursor 	'The current cursor location, wrapped back to the beginning if appropriate' number	 readWrite player getCursor player setCursorWrapped:)
(slot sampleAtCursor	'The sample value at the current cursor location' number readWrite player getSampleAtCursor player setSampleAtCursor:)
(slot lastValue 'The last value obtained' number readWrite	player getLastValue player setLastValue:)
(command clear 'Clear the graph of current contents')
(command loadSineWave 'Load a sine wave as the current graph')
(command loadSound: 'Load the specified sound into the current graph' sound)
(command reverse 'Reverse the graph')
(command play 'Play the current graph as a sound'))))