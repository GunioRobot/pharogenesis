allPathsDo: aBlock
	"For all paths down the tree, evaluate aBlock."

	^ self allPathsDo: aBlock trail: OrderedCollection new