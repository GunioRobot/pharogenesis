additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ #((graphics (
(slot graphic 	'The picture currently being worn' Graphic	 readWrite Player getGraphic Player setGraphic:)
(command wearCostumeOf: 'wear the costume of...' Player)
(slot baseGraphic 	'The picture originally painted for this object, but can subsequently be changed via menu or script' Graphic	 readWrite Player getBaseGraphic Player setBaseGraphic:)
(command restoreBaseGraphic 'Make my picture be the one I remember in my baseGraphic')

(slot rotationStyle 'How the picture should change when the heading is modified' RotationStyle readWrite Player getRotationStyle Player setRotationStyle:)
)))


