at: index
	"Return the Nth color at this depth, as if this were a very big array. Index is 1-order, pixelValues are 0-order.  6/22/96 tk"

	 ^ Color colorFromPixelValue: index-1 depth: depth