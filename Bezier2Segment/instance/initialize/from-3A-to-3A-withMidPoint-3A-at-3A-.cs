from: startPoint to: endPoint withMidPoint: pointOnCurve at: parameter
	"Initialize the receiver with the pointOnCurve at the given parametric value"
	| t1 t2 t3 |
	start _ startPoint.
	end _ endPoint.
	"Compute via"
	t1 _ (1.0 - parameter) squared.
	t2 _ 2 * parameter * (1.0 - parameter).
	t3 _ parameter squared.
	via _ (pointOnCurve * t2) - (start * t1)  - (end * t3)