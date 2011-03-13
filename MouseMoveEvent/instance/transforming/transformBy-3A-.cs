transformBy: aMorphicTransform
	"Transform the receiver into a local coordinate system."
	position _  aMorphicTransform globalPointToLocal: position.
	startPoint _  aMorphicTransform globalPointToLocal: startPoint.