additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ # (

(playfield (
(command initiatePainting 'Initiate painting of a new object in the standard playfield.')
(slot mouseX 'The x coordinate of the mouse pointer' number readWrite player getMouseX  unused unused)
(slot mouseY 'The y coordinate of the mouse pointer' number readWrite player getMouseY  unused unused)
(command roundUpStrays 'Bring all out-of-container subparts back into view.')
(slot numberAtCursor 'the number at the cursor' number readWrite player getNumberAtCursor player setNumberAtCursor: )
(slot playerAtCursor 'the object currently at the cursor' player readWrite player getValueAtCursor  unused unused)
(command unhideHiddenObjects 'Unhide all hidden objects.')))

(collections (
(slot cursor 'The index of the chosen element' number readWrite player getCursor player setCursorWrapped:)
(slot playerAtCursor 'the object currently at the cursor' player readWrite player getValueAtCursor  unused unused)
(slot firstElement  'The first object in my contents' player  readWrite player getFirstElement  player  setFirstElement:)
(slot numberAtCursor 'the number at the cursor' number readWrite player getNumberAtCursor player setNumberAtCursor: )
(command removeAll 'Remove all elements from the playfield')
(command shuffleContents 'Shuffle the contents of the playfield')
(command append: 'Add the object to my content' player)))

(#'stack navigation' (
(command goToNextCardInStack 'Go to the next card')
(command goToPreviousCardInStack  'Go to the previous card')
(command goToFirstCardInBackground 'Go to the first card of the current background')
(command goToFirstCardOfStack 'Go to the first card of the entire stack')
(command goToLastCardInBackground 'Go to the last card of the current background')
(command goToLastCardOfStack 'Go to the last card of the entire stack')
(command deleteCard 'Delete the current card')
(command insertCard 'Create a new card')))

(viewing (
(slot viewingNormally 'whether contents are viewed normally' boolean readWrite player getViewingByIcon player setViewingByIcon: )))


(#'pen trails' (
(command liftAllPens 'Lift the pens on all the objects in my interior.')
(command lowerAllPens  'Lower the pens on all the objects in my interior.')
(command clearTurtleTrails 'Clear all the pen trails in the interior.'))))
