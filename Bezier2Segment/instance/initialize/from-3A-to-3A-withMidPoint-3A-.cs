from: startPoint to: endPoint withMidPoint: pointOnCurve
	"Initialize the receiver with the pointOnCurve assumed at the parametric value 0.5"
	start _ startPoint.
	end _ endPoint.
	"Compute via"
	via _ (pointOnCurve * 2) - ((start+end) // 2).