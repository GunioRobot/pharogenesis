createCategory: aRequestor
	| catName organization node |
	node _ aRequestor requestCurrentNode.
	organization _ node organization.
	catName _ OBTextRequest 
					prompt: 'Please type new category name' 
					template: (self categoryTemplateFor: organization).
	catName ifNotNil:	[organization addCategory: catName.
						aRequestor select: (node categoryNodeNamed: catName)].