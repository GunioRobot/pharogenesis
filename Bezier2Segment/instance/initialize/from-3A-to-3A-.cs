from: startPoint to: endPoint
	"Initialize the receiver as straight line"
	start _ startPoint.
	end _ endPoint.
	via _ (start + end) // 2.