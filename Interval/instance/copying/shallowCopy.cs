shallowCopy
	"Without this method, #copy would return an array instead of a new interval.
	The whole problem is burried in the class hierarchy and every fix will worsen
	the problem, so once the whole issue is resolved one should come back to this 
	method fix it."

	^ self class from: start to: stop by: step