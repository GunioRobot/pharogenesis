valueAt: parameter
	"Return the point at the value parameter:
		p(t) =	(1-t)^2 * p1 + 
				2*t*(1-t) * p2 + 
				t^2 * p3.
	"
	| t1 t2 t3 |
	t1 _ (1.0 - parameter) squared.
	t2 _ 2 * parameter * (1.0 - parameter).
	t3 _ parameter squared.
	^(start * t1) + (via * t2) + (end * t3)