isVisible: aRectangle
	"Optimization of: ^ clipRect intersects: (aRectangle translateBy: origin)"

	^ ((aRectangle right + origin x) < clipRect left or:
	  [(aRectangle left + origin x) > clipRect right or:
	  [(aRectangle bottom + origin y) < clipRect top or:
	  [(aRectangle top + origin y) > clipRect bottom]]]) not
