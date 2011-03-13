rename: aNode
	| category |
	category := OBTextRequest
				prompt: 'Please type new category name' 
				template: aNode name.
	category ifNotNil:	
		[aNode container organization renameCategory: aNode name toBe: category.
		aNode signalChanged]