sumBitsAt: aPoint cellSize: s
	"Return the number of pixels whose value is 1 (black) in the s-by-s cell whose topLeft is aPoint.  Only meaningful for depth 1 forms."
	| bp n |
	n _ 0.
	bp _ BitBlt bitPeekerFromForm: self.
	0 to: s-1 do:
		[:x | 0 to: s-1 do: 
			[:y | n _ n + (bp pixelAt: aPoint + (x@y))]].
	^ n