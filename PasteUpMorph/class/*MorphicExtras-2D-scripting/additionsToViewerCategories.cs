additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ # (

(playfield (
(command initiatePainting 'Initiate painting of a new object in the standard playfield.')
(slot mouseX 'The x coordinate of the mouse pointer' Number readWrite Player getMouseX  unused unused)
(slot mouseY 'The y coordinate of the mouse pointer' Number readWrite Player getMouseY  unused unused)
(command roundUpStrays 'Bring all out-of-container subparts back into view.')
(slot graphic 'The graphic shown in the background of this object' Graphic readWrite Player getGraphic Player setGraphic:)
(command unhideHiddenObjects 'Unhide all hidden objects.')))

(scripting (
(command tellAllContents: 'Send a message to all the objects inside the playfield' ScriptName)))

(collections (
(slot cursor 'The index of the chosen element' Number readWrite Player getCursor Player setCursorWrapped:)
(slot count 'How many elements are within me' Number readOnly Player getCount unused unused)
(slot stringContents 'The characters of the objects inside me, laid end to end' String readOnly Player getStringContents unused unused)
(slot playerAtCursor 'the object currently at the cursor' Player readWrite Player getValueAtCursor  unused unused)
(slot firstElement  'The first object in my contents' Player  readWrite Player getFirstElement  Player  setFirstElement:)
(slot numberAtCursor 'the number at the cursor' Number readWrite Player getNumberAtCursor Player setNumberAtCursor: )
(slot graphicAtCursor 'the graphic worn by the object at the cursor' Graphic readOnly Player getGraphicAtCursor  unused unused)
(command tellAllContents: 'Send a message to all the objects inside the playfield' ScriptName)
(command removeAll 'Remove all elements from the playfield')
(command shuffleContents 'Shuffle the contents of the playfield')
(command append: 'Add the object to the end of my contents list.' Player)
(command prepend: 'Add the object at the beginning of my contents list.' Player)
(command includeAtCursor: 'Add the object to my contents at my current cursor position' Player)
(command include: 'Add the object to my contents' Player)
))

(#'stack navigation' (
(command goToNextCardInStack 'Go to the next card')
(command goToPreviousCardInStack  'Go to the previous card')
(command goToFirstCardInBackground 'Go to the first card of the current background')
(command goToFirstCardOfStack 'Go to the first card of the entire stack')
(command goToLastCardInBackground 'Go to the last card of the current background')
(command goToLastCardOfStack 'Go to the last card of the entire stack')
(command deleteCard 'Delete the current card')
(command insertCard 'Create a new card')))

"(viewing (
(slot viewingNormally 'whether contents are viewed normally' Boolean readWrite Player getViewingByIcon Player setViewingByIcon: )))"

(#'pen trails' (
(command liftAllPens 'Lift the pens on all the objects in my interior.')
(command lowerAllPens  'Lower the pens on all the objects in my interior.')
(command trailStyleForAllPens:  'Set the trail style for pens of all objects within' TrailStyle)
(command clearTurtleTrails 'Clear all the pen trails in the interior.'))))
