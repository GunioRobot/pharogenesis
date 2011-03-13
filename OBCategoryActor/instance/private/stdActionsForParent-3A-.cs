stdActionsForParent: aNode
	^ Array
		with: (OBAction 
				label: 'create category...'
				receiver: self
				selector: #createIn:
				arguments: (Array with: aNode)
				icon: self newIcon)
		with: (OBAction
				label: 'alphabetize categories'
				receiver: self
				selector: #alphabetizeCategoriesIn:
				arguments: (Array with: aNode))
		with: (OBAction
				label: 'remove empty categories'
				receiver: self
				selector: #removeEmptyCategoriesIn:
				arguments: (Array with: aNode organization))
		with: (OBAction
				label: 'reorganize categories'
				receiver: self
				selector: #reorganizeCategoriesIn:
				arguments: (Array with: aNode organization))
