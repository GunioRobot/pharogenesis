popMatrix
	"Pop the current matrix from the stack"
	matrixStack isEmpty ifTrue:[^self error:'Empty matrix stack'].
	currentMatrix loadFrom: matrixStack removeLast.