initialize
	"Initialize the receiver.  In this case we primarily seek to undo the damage done by inherited implementors of #initialize"

	super initialize.
	self removeAllMorphs.
	resultType _ #Boolean.
	self vResizing: #shrinkWrap