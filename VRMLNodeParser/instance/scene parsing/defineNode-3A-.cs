defineNode: aNode
	"Define aNode if necessary"
	defName ifNotNil:[
		scene defineNode: defName value: aNode.
		defName _ nil]
