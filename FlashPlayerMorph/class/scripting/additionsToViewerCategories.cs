additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ # (

(collections (
(slot cursor 'The index of the chosen element' Number readWrite player getCursor player setCursorWrapped:)
(slot playerAtCursor 'the object currently at the cursor' Player readWrite player getValueAtCursor  unused unused)
(slot firstElement  'The first object in my contents' Player  readWrite player getFirstElement  player  setFirstElement:)
(slot graphicAtCursor 'the graphic worn by the object at the cursor' Graphic readOnly player getGraphicAtCursor  unused unused)


))

)
