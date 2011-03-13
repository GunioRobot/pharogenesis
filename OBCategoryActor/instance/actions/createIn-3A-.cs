createIn: aNode
	| catName organization |
	organization := aNode organization.
	catName := OBTextRequest 
					prompt: 'Please type new category name' 
					template: (self categoryTemplateFor: organization).
	catName ifNotNil:	[organization addCategory: catName.
						(aNode categoryNodeNamed: catName) signalSelection].